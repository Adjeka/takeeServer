using Microsoft.AspNetCore.Mvc;
using takee.Contracts.Animals;
using takee.Core.Interfaces.Services;
using takee.Core.Models;

namespace takee.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalsService _animalsService;
        private readonly ITypesOfAnimalsService _typesOfAnimalsService;
        private readonly IBreedsService _breedsService;
        private readonly ICuratorsService _curatorsService;

        public AnimalsController(
            IAnimalsService animalsService, 
            ITypesOfAnimalsService typesOfAnimalsService,
            IBreedsService breedsService,
            ICuratorsService curatorsService)
        {
            _animalsService = animalsService;
            _typesOfAnimalsService = typesOfAnimalsService;
            _breedsService = breedsService;
            _curatorsService = curatorsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AnimalsResponse>>> GetAnimals()
        {
            var animals = await _animalsService.GetAllAnimals();

            var response = animals.Select(a => new AnimalsResponse(
                a.Id,
                a.Nickname,
                a.TypeOfAnimals,
                a.Breed,
                a.Height,
                a.Weight,
                a.Gender.Value,
                a.DateOfBirth,
                a.Color,
                a.DistinguishingMark,
                a.Description,
                a.Curator,
                Convert.ToBase64String(a.Photo)));

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AnimalsResponse>> GetAnimalById(Guid id)
        {
            var animal = await _animalsService.GetAnimalById(id);

            var response = new AnimalsResponse(
                animal.Id,
                animal.Nickname,
                animal.TypeOfAnimals,
                animal.Breed,
                animal.Height,
                animal.Weight,
                animal.Gender.Value,
                animal.DateOfBirth,
                animal.Color,
                animal.DistinguishingMark,
                animal.Description,
                animal.Curator,
                Convert.ToBase64String(animal.Photo));

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAnimal([FromForm] AnimalsRequest request)
        {
            var typeOfAnimals = await _typesOfAnimalsService.GetTypeOfAnimalsById(request.TypeOfAnimalsId);
            var breed = await _breedsService.GetBreedById(request.BreedId);
            var curator = await _curatorsService.GetCuratorById(request.CuratorId);

            var gender = Gender.Create(request.Gender).Value;

            byte[] photo;

            if (request.Photo != null)
            {
                using (var binaryReader = new BinaryReader(request.Photo.OpenReadStream()))
                {
                    photo = binaryReader.ReadBytes((int)request.Photo.Length);
                }
            }
            else throw new ArgumentNullException(nameof(request.Photo));

            var animal = Animal.Create(
                Guid.NewGuid(),
                request.Nickname,
                typeOfAnimals,
                breed,
                request.Height,
                request.Weight,
                gender,
                request.DateOfBirth,
                request.Color,
                request.DistinguishingMark,
                request.Description,
                curator,
                photo);

            if (animal.IsFailure)
                return BadRequest(animal.Error);

            await _animalsService.CreateAnimal(animal.Value);

            return Ok();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateAnimal(Guid id, [FromForm] AnimalsRequest request)
        {
            byte[] photo = null;

            if (request.Photo != null)
            {
                using (var binaryReader = new BinaryReader(request.Photo.OpenReadStream()))
                {
                    photo = binaryReader.ReadBytes((int)request.Photo.Length);
                }
            }
            else
            {
                var animal = await _animalsService.GetAnimalById(id);
                photo = animal.Photo;
            }

            var gender = Gender.Create(request.Gender).Value;

            await _animalsService.UpdateAnimal(
                id,
                request.Nickname,
                request.TypeOfAnimalsId,
                request.BreedId,
                request.Height,
                request.Weight,
                gender,
                request.DateOfBirth,
                request.Color,
                request.DistinguishingMark,
                request.Description,
                request.CuratorId,
                photo);

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteAnimal(Guid id)
        {
            await _animalsService.DeleteAnimal(id);

            return Ok();
        }
    }
}
