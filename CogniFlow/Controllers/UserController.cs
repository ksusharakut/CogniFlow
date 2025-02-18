using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CogniFlow.Models;
using System.Runtime.CompilerServices;
using CogniFlow.Data;
using CogniFlow.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;
using CogniFlow.DTOs;
using CogniFlow.Services.Interfaces;
using CogniFlow.Services;


namespace CogniFlow.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserReturnDTO>>> GetUsers()
        {
            var users = await _userService.GetUsersAsync();

            if (users == null || users.Count == 0)
            {
                return NotFound("No users found");
            }

            return Ok(users);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<UserReturnDTO>> GetUserById(int userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);

            if (user == null)
            {
                return NotFound($"No user with id: {userId}");
            }

            return Ok(user);
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult<UserReturnDTO>> UpdateUser(int userId, [FromBody] UserUpdateDTO userUpdateDTO)
        {
            try
            {
                var updatedUser = await _userService.UpdateUserAsync(userId, userUpdateDTO);

                return Ok(updatedUser);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<UserReturnDTO>> CreateUser([FromBody]UserCreateDTO userCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdUser = await _userService.CreateUserAsync(userCreateDTO);
                return Ok(userCreateDTO);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult> DeleteUserById(int userId)
        {
            bool success = await _userService.DeleteUserAsync(userId);

            if (!success)
            {
                return NotFound($"No user found with id: {userId}");
            }

            return Ok("User was successfully deleted");
        }
       
    }
}
