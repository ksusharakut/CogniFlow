using AutoMapper;
using CogniFlow.DTOs;
using CogniFlow.Models.Entities;

namespace CogniFlow.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile() 
        {
            CreateMap<RoleDTO, RoleReturnDTO>();

            CreateMap<RoleDTO, Role>();

            CreateMap<Role, RoleReturnDTO>();
        }
    }
}
