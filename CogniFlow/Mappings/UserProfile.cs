    using AutoMapper;
    using CogniFlow.DTOs;
    using CogniFlow.Models.Entities;
    using CogniFlow.Utilities;
    using CogniFlow.Utilities.Interfaces;

    namespace CogniFlow.Mappings
    {
        public class UserProfile : Profile
        {
            public UserProfile() 
            {
                CreateMap<UserCreateDTO, User>()
                    .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                    .ForMember(dest => dest.PasswordSalt, opt => opt.Ignore());

                CreateMap<User, UserReturnDTO>();

                CreateMap<UserUpdateDTO, User>()
                    .ForMember(dest => dest.UserId, opt => opt.Ignore())
                    .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
                    .ForMember(dest => dest.PasswordSalt, opt => opt.Ignore())
                    .ForMember(dest => dest.RoleId, opt => opt.Ignore());
            }
           
        }
    }
