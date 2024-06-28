using Microsoft.AspNetCore.Mvc;
using takee.Contracts.UserRoles;
using takee.Core.Interfaces.Services;
using takee.Core.Models;

namespace takee.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserRolesController : ControllerBase
    {
        private readonly IUserRolesService _userRolesService;

        public UserRolesController(IUserRolesService userRolesService)
        {
            _userRolesService = userRolesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserRolesResponse>>> GetUserRoles()
        {
            var userRoles = await _userRolesService.GetAllUserRoles();

            var response = userRoles.Select(ur => new UserRolesResponse(ur.Id, ur.Name));

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UserRolesResponse>> GetUserRoleById(Guid id)
        {
            var userRole = await _userRolesService.GetUserRoleById(id);

            var response = new UserRolesResponse(userRole.Id, userRole.Name);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUserRole([FromBody] UserRolesRequest request)
        {
            var userRole = UserRole.Create(
                Guid.NewGuid(),
                request.Name);

            if (userRole.IsFailure)
                return BadRequest(userRole.Error);

            await _userRolesService.CreateUserRole(userRole.Value);

            return Ok();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateUserRole(Guid id, [FromBody] UserRolesRequest request)
        {
            await _userRolesService.UpdateUserRole(id, request.Name);

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteUserRole(Guid id)
        {
            await _userRolesService.DeleteUserRole(id);

            return Ok();
        }
    }
}
