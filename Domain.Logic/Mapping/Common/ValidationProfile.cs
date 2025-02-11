using AutoMapper;
using Domain.DTO.Messages;
using Domain.DTO.Messages.Enums;
using fv = FluentValidation;

namespace Domain.Logic.Mapping.Common
{
    public class ValidationProfile : Profile
    {
        public ValidationProfile()
        {
            CreateMap<fv.Results.ValidationFailure, IMessage>()
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.ErrorMessage))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(_ => MessageType.Error))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.ErrorCode));
        }
    }
}
