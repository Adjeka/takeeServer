using Microsoft.AspNetCore.Mvc;
using takee.Contracts.Breeds;
using takee.Core.Interfaces.Services;
using takee.Core.Models;

namespace takee.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BreedsController : ControllerBase
    {
        private readonly IBreedsService _breedsService;

        public BreedsController(IBreedsService breedsService)
        {
            _breedsService = breedsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BreedsResponse>>> GetBreeds()
        {
            var breeds = await _breedsService.GetAllBreeds();

            var response = breeds.Select(b => new BreedsResponse(b.Id, b.Name));

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<BreedsResponse>> GetBreedById(Guid id)
        {
            var breed = await _breedsService.GetBreedById(id);

            var response = new BreedsResponse(breed.Id, breed.Name);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateBreed([FromBody] BreedsRequest request)
        {
            var breed = Breed.Create(
                Guid.NewGuid(),
                request.Name);

            if (breed.IsFailure)
                return BadRequest(breed.Error);

            await _breedsService.CreateBreed(breed.Value);

            return Ok();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateBreed(Guid id, [FromBody] BreedsRequest request)
        {
            await _breedsService.UpdateBreed(id, request.Name);

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteBreed(Guid id)
        {
            await _breedsService.DeleteBreed(id);

            return Ok();
        }
    }
}
