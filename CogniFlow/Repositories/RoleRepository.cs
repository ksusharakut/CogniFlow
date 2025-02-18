using CogniFlow.Data;
using CogniFlow.Models.Entities;
using CogniFlow.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CogniFlow.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Role> CreateRoleAsync(Role role)
        {
            _context.Role.Add(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<bool> DeleteRoleAsync(Role role)
        {
            _context.Role.Remove(role);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Role>> GetAllRolesAsync()
        {
            return await _context.Role.ToListAsync();
        }

        public async Task<Role> GetRoleByIdAsync(int roleId)
        {
            return await _context.Role.FirstOrDefaultAsync(r => r.RoleId == roleId);
        }

        public async Task<Role> GetRoleByRoleNameAsync(string roleName)
        {
            return await _context.Role.FirstOrDefaultAsync(r => r.RoleName == roleName);
        }

        public async Task<bool> IsRoleNameUniqueAsync(string roleName)
        {
            var existingRole = await _context.Role.FirstOrDefaultAsync(r => r.RoleName == roleName);
            return existingRole == null;
        }

        public async Task<bool> RoleExistAsync(int roleId)
        {
            return await _context.Role.AnyAsync(r => r.RoleId == roleId);
        }

        public async Task<Role> UpdateRoleAsync(Role role)
        {
            _context.Role.Update(role);
            await _context.SaveChangesAsync();
            return role;
        }

    }
}
