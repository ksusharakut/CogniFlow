using CogniFlow.Data;
using CogniFlow.DTOs;
using CogniFlow.Models.Entities;
using CogniFlow.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CogniFlow.Controllers
{
    [Route("api/roles")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleReturnDTO>>> GetRoles()
        {
            var roles = await _roleService.GetAllRolesAsync();

            if(roles == null || roles.Count == 0)
            {
                return NotFound("No users found");
            }

            return Ok(roles);
        }

        [HttpGet("{roleId}")]
        public async Task<ActionResult<RoleReturnDTO>> GetRoleById(int roleId)
        {
            var role = await _roleService.GetRoleByIdAsync(roleId);

            if(role == null)
            {
                return NotFound($"No role with id {roleId}");
            }

            return Ok(role);
        }

        [HttpDelete("{roleId}")]
        public async Task<ActionResult> DeleteRoleById(int roleId)
        {
            bool success = await _roleService.DeleteRoleAsync(roleId);

            if (!success)
            {
                return NotFound($"No role found with id: {roleId}");
            }

            return Ok($"Role with id: {roleId} was successfully deleted");
        }

        [HttpPost]
        public async Task<ActionResult<RoleReturnDTO>> CreateRole([FromBody] RoleDTO roleDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var createdRole = await _roleService.CreateRoleAsync(roleDTO);
                return Ok(createdRole);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{roleId}")]
        public async Task<ActionResult<RoleReturnDTO>> Role(int roleId, [FromBody] RoleDTO roleDTO)
        {
            try
            {
                var updatedRole = await _roleService.UpdateRoleAsync(roleId,roleDTO);

                return Ok(updatedRole);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
