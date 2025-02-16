using CogniFlow.Models.Entities;

namespace CogniFlow.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
    }
}
