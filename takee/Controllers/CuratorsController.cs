using Microsoft.AspNetCore.Mvc;
using takee.Application.Services;
using takee.Contracts.Curators;
using takee.Contracts.Users;
using takee.Core.Interfaces.Services;
using takee.Core.Models;

namespace takee.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CuratorsController : ControllerBase
    {
        private readonly ICuratorsService _curatorsService;

        public CuratorsController(ICuratorsService curatorsService)
        {
            _curatorsService = curatorsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CuratorsResponse>>> GetCurators()
        {
            var curators = await _curatorsService.GetAllCurators();

            var response = curators.Select(c => new CuratorsResponse(
                c.Id, 
                c.Surname, 
                c.Name, 
                c.Patronymic, 
                c.Email.Mail, 
                c.PhoneNumber.Number));

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CuratorsResponse>> GetCuratorById(Guid id)
        {
            var curator = await _curatorsService.GetCuratorById(id);

            var response = new CuratorsResponse(
                curator.Id,
                curator.Surname,
                curator.Name,
                curator.Patronymic,
                curator.Email.Mail,
                curator.PhoneNumber.Number);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCurator([FromBody] CuratorsRequest request)
        {
            var email = Email.Create(request.Email).Value;
            var phoneNumber = PhoneNumber.Create(request.PhoneNumber).Value;

            var curator = Curator.Create(
                Guid.NewGuid(),
                request.Surname,
                request.Name,
                request.Patronymic,
                email,
                phoneNumber);

            if (curator.IsFailure)
                return BadRequest(curator.Error);

            await _curatorsService.CreateCurator(curator.Value);

            return Ok();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateCurator(Guid id, [FromBody] CuratorsRequest request)
        {
            var email = Email.Create(request.Email).Value;
            var phoneNumber = PhoneNumber.Create(request.PhoneNumber).Value;

            await _curatorsService.UpdateCurator(
                id,
                request.Surname,
                request.Name,
                request.Patronymic,
                email,
                phoneNumber);

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteCurator(Guid id)
        {
            await _curatorsService.DeleteCurator(id);

            return Ok();
        }
    }
}
