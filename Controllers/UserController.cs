﻿using AllocationTeamAPI.Models;
using AllocationTeamAPI.Services;
using Microsoft.AspNetCore.Mvc;
namespace AllocationTeamAPI.Controllers

    {
        [Route("api/[controller]")]
        [ApiController]
        public class UsersController : ControllerBase
        {
            private readonly UserService _userService;

            public UsersController(UserService userService)
            {
                _userService = userService;
            }

            [HttpGet]
            public async Task<IActionResult> GetAllUsers()
            {
                var users = await _userService.GetAllUsersAsync();
                return Ok(users);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetUserById(int id)
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }

            [HttpPost]
            public async Task<IActionResult> CreateUser([FromBody] User user)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var createdUser = await _userService.CreateUserAsync(user);
                return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
            {
                if (id != user.Id)
                {
                    return BadRequest();
                }
                await _userService.UpdateUserAsync(user);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteUser(int id)
            {
                await _userService.DeleteUserAsync(id);
                return NoContent();
            }
        }
    }
