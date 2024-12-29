using AutoMapper;
using DataAccess.DTO.Membership;
using DataAccess.Entities.Membership;

namespace DataAccess.Mapping.Membership
{
    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>()
                .ReverseMap();
        }
    }
}
