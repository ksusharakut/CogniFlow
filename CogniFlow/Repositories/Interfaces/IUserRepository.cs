using CogniFlow.DTOs;
using CogniFlow.Models.Entities;

namespace CogniFlow.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();

        Task<User> GetUserByIdAsync(int userId);

        Task<User> CreateUserAsync(User user);

        Task<User> GetUserByEmailAsync(string email);

        Task<bool> DeleteUserAsync(User user);

        Task<User> UpdateUserAsync(User user);

        Task<bool> IsEmailUniqueAsync(string email);
    }
}
