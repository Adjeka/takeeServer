using Microsoft.AspNetCore.Mvc;
using takee.Contracts.TypesOfAnimals;
using takee.Core.Interfaces.Services;
using takee.Core.Models;

namespace takee.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TypesOfAnimalsController : ControllerBase
    {
        private readonly ITypesOfAnimalsService _typesOfAnimalsService;

        public TypesOfAnimalsController(ITypesOfAnimalsService typesOfAnimalsService)
        {
            _typesOfAnimalsService = typesOfAnimalsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TypesOfAnimalsResponse>>> GetTypesOfAnimals()
        {
            var typesOfAnimals = await _typesOfAnimalsService.GetAllTypesOfAnimals();

            var response = typesOfAnimals.Select(t => new TypesOfAnimalsResponse(t.Id, t.Name));

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TypesOfAnimalsResponse>> GetTypeOfAnimalsById(Guid id)
        {
            var typeOfAnimals = await _typesOfAnimalsService.GetTypeOfAnimalsById(id);

            var response = new TypesOfAnimalsResponse(typeOfAnimals.Id, typeOfAnimals.Name);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTypeOfAnimals([FromBody] TypesOfAnimalsRequest request)
        {
            var typeOfAnimals = TypeOfAnimals.Create(
                Guid.NewGuid(),
                request.Name);

            if (typeOfAnimals.IsFailure)
                return BadRequest(typeOfAnimals.Error);

            await _typesOfAnimalsService.CreateTypeOfAnimals(typeOfAnimals.Value);

            return Ok();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateTypeOfAnimals(Guid id, [FromBody] TypesOfAnimalsRequest request)
        {
            await _typesOfAnimalsService.UpdateTypeOfAnimals(id, request.Name);

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteTypeOfAnimals(Guid id)
        {
            await _typesOfAnimalsService.DeleteTypeOfAnimals(id);

            return Ok();
        }
    }
}
