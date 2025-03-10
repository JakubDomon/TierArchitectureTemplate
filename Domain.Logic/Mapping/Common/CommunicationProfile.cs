using AutoMapper;
using domainLayer = Domain.DTO.Common.Enums;
using dataLayer = DataAccess.DTO.Common.CommunicationObjects.Enums;

namespace Domain.Logic.Mapping.Common
{
    internal class CommunicationProfile : Profile
    {
        public CommunicationProfile()
        {
            CreateMap<domainLayer.OperationDetail, dataLayer.OperationDetail>()
                .ReverseMap();
        }
    }
}
