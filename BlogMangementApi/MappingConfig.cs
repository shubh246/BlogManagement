using AutoMapper;
using Models;
using Models.Dto;

namespace BlogMangementApi
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Subscription, SubscriptionDto>().ReverseMap();
        }
    }
}
