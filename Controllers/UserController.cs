using AllocationTeamAPI.Models;
using AllocationTeamAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using AllocationTeamAPI.Dtos;
using AllocationTeamAPI.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace AllocationTeamAPI.Controllers

    {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
        {
            private readonly UserService _userService;
            private readonly ITokenManager _tokenManager;

        public UsersController(UserService userService, ITokenManager tokenManager)
        {
            _userService = userService;
            _tokenManager = tokenManager;
        }


        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateRequest userUpdateReqeust)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
            {
                return Unauthorized("Bad identification.");
            }
            string nameToChane = "";
            if (!string.IsNullOrEmpty(userUpdateReqeust.Username))
            {
                nameToChane = await _userService.UpdateUserName(int.Parse(userIdClaim), userUpdateReqeust.Username);
            }
            bool isChange = false;
            if (!string.IsNullOrEmpty(userUpdateReqeust.Password) && userUpdateReqeust.Password.Length>5)
            {
                isChange = await _userService.UpdateUserPassword(int.Parse(userIdClaim), userUpdateReqeust.Password);
            }
            return Ok($"update user change user name to: {nameToChane} and password is update: {isChange}");

        }

        [HttpDelete]
            public async Task<IActionResult> DeleteUser()
            {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null)
            {
                return Unauthorized("Bad identification.");
            }
            var authorizationHeader = HttpContext.Request.Headers["Authorization"].ToString();

            if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
            {
                var token = authorizationHeader.Substring("Bearer ".Length).Trim();
                _tokenManager.DisableToken(token);
                await _userService.DeleteUserAsync(int.Parse(userIdClaim));
            }
            return NoContent();
        }

    }
    }

