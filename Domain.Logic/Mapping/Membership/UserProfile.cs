﻿using AutoMapper;
using domainDto = Domain.DTO.Models.Membership;
using Domain.Models.BusinessModels.Membership;
using DataAccess.DTO.Membership;

namespace Domain.Logic.Mapping.Membership
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, domainDto.UserDto>()
                .ReverseMap();
            CreateMap<User, UserDto>()
                .ReverseMap();
        }
    }
}
