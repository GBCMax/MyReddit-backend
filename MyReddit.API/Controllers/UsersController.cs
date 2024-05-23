using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyReddit.API.Contracts.Users;
using MyReddit.Application.Services;
using MyReddit.Core.Interfaces.Services;
using MyReddit.Core.Models;
using MyReddit.DataAccess.Repositories;

namespace MyReddit.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _usersService;
        private readonly IHttpContextAccessor _context;
        public UsersController(IUserService userService, IHttpContextAccessor context)
        {
            _usersService = userService;
            _context = context;

        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<UsersResponse>>> GetUsers()
        {
            var users = await _usersService.GetAllUsers();

            var response = users.Select(x => new UsersResponse(x.Id, x.UserName, x.Password, x.Email));

            return Ok(response);
        }

        [HttpGet("GetUserByEmail")]
        public async Task<ActionResult<UsersResponse>> GetUserByEmail([FromQuery] string email)
        {
            var user = await _usersService.GetUserByEmail(email);

            if(user == null)
            {
                return BadRequest("Не найдено!");
            }

            var response = new UsersRequest(user.UserName, user.Password, user.Email);

            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<ActionResult<RegisterUserRequest>> Register([FromBody] RegisterUserRequest request)
        {
            await _usersService.Register(request.UserName, request.Email, request.Password);

            return Ok();
        }

        [HttpPost("Login")]
        public async Task<ActionResult<LoginUserRequest>> Login([FromBody] LoginUserRequest request)
        {
            var token = await _usersService.Login(request.Email, request.Password);

            _context.HttpContext?.Response.Cookies.Append("my-cookies", token);

            return Ok(token);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateUser(Guid id, [FromBody] UsersRequest request)
        {
            var userId = await _usersService.UpdateUser(id, request.Name, request.Password, request.Email);

            return Ok(userId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteUser(Guid id)
        {
            return Ok(await _usersService.DeleteUser(id));
        }
    }
}
