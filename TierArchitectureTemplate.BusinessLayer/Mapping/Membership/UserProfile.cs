using AutoMapper;
using BusinessLayer.Models.BusinessModels.Membership;
using BusinessLayer.Models.Communication.Messages.Requests.Specific.Membership;
using DataAccessLayer.DTO.Membership;

namespace BusinessLayer.Logic.Mapping.Membership
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>()
                .ReverseMap();
        }
    }
}
