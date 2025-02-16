using AutoMapper;
using CogniFlow.DTOs;
using CogniFlow.Models.Entities;

namespace CogniFlow.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<User, UserReturnDTO>();
        }
    }
}
