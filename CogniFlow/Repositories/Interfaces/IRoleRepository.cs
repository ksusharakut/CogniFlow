using CogniFlow.Models.Entities;

namespace CogniFlow.Repositories.Interfaces
{
    public interface IRoleRepository
    {
        Task<bool> RoleExistAsync(int roleId);

        Task<Role> CreateRoleAsync(Role role);

        Task<bool> DeleteRoleAsync(Role role);

        Task<Role> UpdateRoleAsync(Role role);

        Task<Role> GetRoleByIdAsync(int roleId);

        Task<List<Role>> GetAllRolesAsync();

        Task<Role> GetRoleByRoleNameAsync(string roleName);

        Task<bool> IsRoleNameUniqueAsync(string roleName);
    }
}
