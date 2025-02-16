using CogniFlow.Data;
using CogniFlow.Models.Entities;
using CogniFlow.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CogniFlow.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

    }
}
