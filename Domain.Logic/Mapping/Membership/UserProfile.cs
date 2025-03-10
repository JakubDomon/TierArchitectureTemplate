using AutoMapper;
using Domain.Models.BusinessModels.Membership;
using DataAccess.DTO.Membership;

namespace Domain.Logic.Mapping.Membership
{
    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ReverseMap();
        }
    }
}
