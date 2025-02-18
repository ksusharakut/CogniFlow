using CogniFlow.DTOs;

namespace CogniFlow.Services.Interfaces
{
    public interface IRoleService
    {
        Task<List<RoleReturnDTO>> GetAllRolesAsync();

        Task<RoleReturnDTO> GetRoleByIdAsync(int roleId);

        Task<RoleReturnDTO> CreateRoleAsync(RoleDTO roleDTO);

        Task<bool> DeleteRoleAsync(int roleId);

        Task<RoleReturnDTO> UpdateRoleAsync(int roleId, RoleDTO roleDTO);
    }
}
