using AutoMapper;
using CogniFlow.DTOs;
using CogniFlow.Repositories.Interfaces;
using CogniFlow.Models.Entities;
using CogniFlow.Services.Interfaces;
using CogniFlow.Utilities.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CogniFlow.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHandler _passwordHandler;
        private readonly IRoleRepository _roleRepository;

        public UserService(IUserRepository userRepository, IMapper mapper, IPasswordHandler passwordHandler, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHandler = passwordHandler;
            _roleRepository = roleRepository;
        }

        public async Task<UserReturnDTO> CreateUserAsync(UserCreateDTO userCreateDTO)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(userCreateDTO.Email);
            if (existingUser != null)
            {
                throw new ArgumentException("A user with this email already exist");
            }

            bool roleExist = await _roleRepository.RoleExistAsync(userCreateDTO.RoleId);
            if (!roleExist)
            {
                throw new ArgumentException($"No role with id: {userCreateDTO.RoleId}");
            }

            var user = _mapper.Map<User>(userCreateDTO);

            string salt = _passwordHandler.GenerateSalt();
            user.PasswordSalt = salt;
            user.PasswordHash = _passwordHandler.HashPassword(userCreateDTO.Password, salt);

            var createdUser = await _userRepository.CreateUserAsync(user);

            return _mapper.Map<UserReturnDTO>(createdUser);
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                return false; 
            }

            var result = await _userRepository.DeleteUserAsync(user);
            return result;
        }

        public async Task<UserReturnDTO> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            return _mapper.Map<UserReturnDTO>(user);
        }

        public async Task<List<UserReturnDTO>> GetUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();

            return _mapper.Map<List<UserReturnDTO>>(users);
        }

        public async Task<UserReturnDTO> UpdateUserAsync(int userId, UserUpdateDTO userUpdateDTO)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);

            if (user == null)
            {
                throw new ArgumentException($"No user with id: {userId}");
            }

            if (ShouldUpdateEmail(userUpdateDTO.Email, user.Email))
            {
                await ValidateEmailUniquenessAsync(userUpdateDTO.Email);
                user.Email = userUpdateDTO.Email;
            }

            user.FirstName = string.IsNullOrWhiteSpace(userUpdateDTO.FirstName) ? user.FirstName : userUpdateDTO.FirstName;
            user.LastName = string.IsNullOrWhiteSpace(userUpdateDTO.LastName) ? user.LastName : userUpdateDTO.LastName;
            user.DateBirth = userUpdateDTO.DateBirth ?? user.DateBirth;
            user.UpdatedAt = DateTimeOffset.UtcNow;

            var updatedUser = await _userRepository.UpdateUserAsync(user);

            return _mapper.Map<UserReturnDTO>(updatedUser);
        }

        private bool ShouldUpdateEmail(string newEmail, string currentEmail)
        {
            return !string.IsNullOrWhiteSpace(newEmail) && newEmail != currentEmail;
        }

        private async Task ValidateEmailUniquenessAsync(string email)
        {
            var isEmailUnique = await _userRepository.IsEmailUniqueAsync(email);
            if (!isEmailUnique)
            {
                throw new ArgumentException("A user with this email already exists");
            }
        }

    }
}
