using AutoMapper;
using DataAccess.DTO.Membership;
using DataAccess.Logic.Entities.Membership;

namespace DataAccess.Logic.Mapping.Membership
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
