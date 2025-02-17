using CogniFlow.DTOs;

namespace CogniFlow.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserReturnDTO>> GetUsersAsync();

        Task<UserReturnDTO> GetUserByIdAsync(int userId);

        Task<UserReturnDTO> CreateUserAsync(UserCreateDTO userCreateDTO);

        Task<bool> DeleteUserAsync(int userId);

        Task<UserReturnDTO> UpdateUserAsync(int userId, UserUpdateDTO userUpdateDTO);
    }
}
