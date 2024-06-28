using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using takee.Contracts.Users;
using takee.Core.Interfaces.Services;
using takee.Core.Models;

namespace takee.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IUserRolesService _userRolesService;

        public UsersController(IUsersService usersService, IUserRolesService userRolesService) 
        {
            _usersService = usersService;
            _userRolesService = userRolesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsersResponse>>> GetUsers()
        {
            var users = await _usersService.GetAllUsers();

            var response = users.Select(u => new UsersResponse(
                u.Id, 
                u.Surname, 
                u.Name, 
                u.Patronymic, 
                u.DateOfBirth, 
                u.Email.Mail, 
                u.PhoneNumber.Number, 
                u.UserRole, 
                u.Login, 
                u.Password));

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UsersResponse>> GetUserById(Guid id)
        {
            var user = await _usersService.GetUserById(id);

            var response = new UsersResponse(
                user.Id, 
                user.Surname, 
                user.Name, 
                user.Patronymic, 
                user.DateOfBirth, 
                user.Email.Mail, 
                user.PhoneNumber.Number, 
                user.UserRole, 
                user.Login, 
                user.Password);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] UsersRequest request)
        {
            var email = Email.Create(request.Email).Value;
            var phoneNumber = PhoneNumber.Create(request.PhoneNumber).Value;

            var userRole = await _userRolesService.GetUserRoleById(request.UserRoleId);

            var user = Core.Models.User.Create(
                Guid.NewGuid(),
                request.Surname,
                request.Name,
                request.Patronymic,
                request.DateOfBirth,
                email,
                phoneNumber,
                userRole,
                request.Login,
                request.Password);

            if (user.IsFailure)
                return BadRequest(user.Error);

            await _usersService.CreateUser(user.Value);

            return Ok();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateUser(Guid id, [FromBody] UsersRequest request)
        {
            var email = Email.Create(request.Email).Value;
            var phoneNumber = PhoneNumber.Create(request.PhoneNumber).Value;

            await _usersService.UpdateUser(
                id,
                request.Surname,
                request.Name,
                request.Patronymic,
                request.DateOfBirth,
                email,
                phoneNumber,
                request.UserRoleId,
                request.Login,
                request.Password);

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            await _usersService.DeleteUser(id);

            return Ok();
        }
    }
}
