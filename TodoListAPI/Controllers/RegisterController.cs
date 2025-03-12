using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TodoListAPI.DTOs;
using TodoListAPI.Service;

namespace TodoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IUserService _userService;

        public RegisterController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] CreateUserDto input)
        {
            var result = await _userService.RegisterUser(input);

            if(result.Code == (int)HttpStatusCode.BadRequest)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
