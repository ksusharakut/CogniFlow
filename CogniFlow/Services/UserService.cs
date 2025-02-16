using AutoMapper;
using CogniFlow.DTOs;
using CogniFlow.Repositories.Interfaces;
using CogniFlow.Services.Interfaces;

namespace CogniFlow.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserReturnDTO>> GetUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();

            return _mapper.Map<List<UserReturnDTO>>(users);
        }
    }
}
