// Ignore Spelling: Auth Dto

using AllocationTeamAPI.Configuration;
using AllocationTeamAPI.Dtos;
using AllocationTeamAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AllocationTeamAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;
        public AuthController(UserService userService) {
            _userService = userService;
        }

        [HttpPost("registration/")]
        public async Task<IActionResult> Registration([FromBody] UserRegisterRequest userDto)
        {
            if (await _userService.RegisterUser(userDto)){
                return Ok("Registration successfully");
            }
            return BadRequest();
        }

        [HttpPost("login/")]
        public async Task<IActionResult> Login([FromBody] UserRegisterRequest userDto)
        {
            UserLoginResponse user = await _userService.LoginUserAsync(userDto.Email, userDto.Password);
            if (user!=null)
            {
                return Ok(user);
            }
            return BadRequest();
        }
    }
}
