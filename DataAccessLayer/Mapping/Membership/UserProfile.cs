using AutoMapper;
using DataAccessLayer.DTO.Membership;
using DataAccessLayer.Entities.Membership;

namespace DataAccessLayer.Mapping.Membership
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
