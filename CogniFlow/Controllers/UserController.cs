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

       
    }
}
