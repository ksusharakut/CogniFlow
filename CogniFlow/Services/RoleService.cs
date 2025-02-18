using AutoMapper;
using CogniFlow.DTOs;
using CogniFlow.Models.Entities;
using CogniFlow.Repositories.Interfaces;
using CogniFlow.Services.Interfaces;

namespace CogniFlow.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(IMapper mapper, IRoleRepository roleRepository)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
        }

        public async Task<RoleReturnDTO> CreateRoleAsync(RoleDTO roleDTO)
        {
            var existingRole = await _roleRepository.GetRoleByRoleNameAsync(roleDTO.RoleName);

            if(existingRole != null)
            {
                throw new ArgumentException("A role with this role name is already exist");
            }

            var newRole = new Role
            {
                RoleName = roleDTO.RoleName
            };

            var createdRole = await _roleRepository.CreateRoleAsync(newRole);

            return _mapper.Map<RoleReturnDTO>(createdRole);
        }

        public async Task<bool> DeleteRoleAsync(int roleId)
        {
            var role = await _roleRepository.GetRoleByIdAsync(roleId);

            if(role == null)
            {
                return false;
            }

            var result = await _roleRepository.DeleteRoleAsync(role);
            return result;
        }

        public async Task<List<RoleReturnDTO>> GetAllRolesAsync()
        {
            var roles = await _roleRepository.GetAllRolesAsync();

            return _mapper.Map<List<RoleReturnDTO>>(roles);
        }

        public async Task<RoleReturnDTO> GetRoleByIdAsync(int roleId)
        {
            var role = await _roleRepository.GetRoleByIdAsync(roleId);
            return _mapper.Map<RoleReturnDTO>(role);
        }

        public async Task<RoleReturnDTO> UpdateRoleAsync(int roleId, RoleDTO roleDTO)
        {
            var role = await _roleRepository.GetRoleByIdAsync(roleId);

            if (role == null)
            {
                throw new ArgumentException($"No role with id: {roleId}");
            }

            role.RoleName = roleDTO.RoleName;
            //role.RoleName = string.IsNullOrWhiteSpace(roleDTO.RoleName) ? role.RoleName : roleDTO.RoleName;

            var updatedRole = await _roleRepository.UpdateRoleAsync(role);

            return _mapper.Map<RoleReturnDTO>(updatedRole);
        }
    }
}
