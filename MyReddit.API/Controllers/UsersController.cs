using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyReddit.API.Contracts;
using MyReddit.Core.Interfaces;
using MyReddit.Core.Models;
using MyReddit.DataAccess.Repositories;

namespace MyReddit.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _usersService;
        public UsersController(IUserService userService)
        {
            _usersService = userService;
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

        [HttpPost]
        public async Task<ActionResult<Guid>> AddUser([FromBody] UsersRequest request)
        {
            var (user, error) = Core.Models.User.Create(
                Guid.NewGuid(),
                request.Name,
                request.Password,
                request.Email);

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var userId = await _usersService.AddUser(user);

            return Ok(userId);
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
