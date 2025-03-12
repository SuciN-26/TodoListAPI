using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TodoListAPI.DTOs;
using TodoListAPI.Service;

namespace TodoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUserDto input)
        {
            var result = await _userService.LoginUser(input);

            if (result.Code == (int)HttpStatusCode.Unauthorized)
            {
                return Unauthorized(result);
            }

            return Ok(result);
        }
    }
}
