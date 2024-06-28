using Microsoft.AspNetCore.Mvc;
using takee.Contracts.RecordsForWalk;
using takee.Core.Interfaces.Services;
using takee.Core.Models;

namespace takee.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecordsForWalkController : ControllerBase
    {
        private readonly IRecordsForWalkService _recordsForWalkService;
        private readonly IUsersService _usersService;
        private readonly IAnimalsService _animalsService;

        public RecordsForWalkController(
            IRecordsForWalkService recordsForWalkService, 
            IUsersService usersService,
            IAnimalsService animalsService)
        {
            _recordsForWalkService = recordsForWalkService;
            _usersService = usersService;
            _animalsService = animalsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<RecordsForWalkResponse>>> GetRecordsForWalk()
        {
            var recordsForWalk = await _recordsForWalkService.GetAllRecordsForWalk();

            var response = recordsForWalk.Select(r => new RecordsForWalkResponse(
                r.Id,
                r.User,
                r.Animal,
                r.DateOfRecord));

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<RecordsForWalkResponse>> GetRecordForWalkById(Guid id)
        {
            var recordForWalk = await _recordsForWalkService.GetRecordForWalkById(id);

            var response = new RecordsForWalkResponse(
                recordForWalk.Id,
                recordForWalk.User,
                recordForWalk.Animal,
                recordForWalk.DateOfRecord);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRecordForWalk([FromBody] RecordsForWalkRequest request)
        {
            var user = await _usersService.GetUserById(request.UserId);
            var animal = await _animalsService.GetAnimalById(request.AnimalId);

            var recordForWalk = RecordForWalk.Create(
                Guid.NewGuid(),
                user,
                animal,
                DateTime.Now);

            if (recordForWalk.IsFailure)
                return BadRequest(recordForWalk.Error);

            await _recordsForWalkService.CreateRecordForWalk(recordForWalk.Value);

            return Ok();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateRecordForWalk(Guid id, [FromBody] RecordsForWalkRequest request)
        {
            await _recordsForWalkService.UpdateRecordForWalk(id, request.UserId, request.AnimalId, DateTime.Now);

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteRecordForWalk(Guid id)
        {
            await _recordsForWalkService.DeleteRecordForWalk(id);

            return Ok();
        }
    }
}
