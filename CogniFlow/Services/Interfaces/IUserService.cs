using CogniFlow.DTOs;

namespace CogniFlow.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserReturnDTO>> GetUsersAsync();
    }
}
