using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using takee.Application.Services;
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
            var userRole = await _userRolesService.GetUserRoleById(request.UserRoleId);

            await _usersService.CreateUser(
                request.Surname,
                request.Name,
                request.Patronymic,
                request.DateOfBirth,
                request.Email,
                request.PhoneNumber,
                userRole,
                request.Login,
                request.Password);

            return Ok();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> UpdateUser(Guid id, [FromBody] UsersRequest request)
        {
            await _usersService.UpdateUser(
                id,
                request.Surname,
                request.Name,
                request.Patronymic,
                request.DateOfBirth,
                request.Email,
                request.PhoneNumber,
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

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register([FromBody] RegisterUserRequest request)
        {
            var userRole = await _userRolesService.GetUserRoleByName("user");

            await _usersService.Register(
                request.Surname,
                request.Name,
                request.Patronymic,
                request.DateOfBirth,
                request.Email,
                request.PhoneNumber,
                userRole,
                request.Login,
                request.Password);

            return Ok();
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<LoginResponse>> Login([FromBody] LoginUserRequest request)
        {
            var token = await _usersService.Login(request.Login, request.Password);

            HttpContext.Response.Cookies.Append("secretCookie", token.Item1);

            var loginResponse = new LoginResponse(token.Item1, token.Item2); 

            return Ok(loginResponse);
        }
    }
}
