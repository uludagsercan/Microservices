using AutoMapper;
using FreeCourse.Services.Basket.Aplication.Services.Features.BasketFeature.Commands.CreateOrUpdateBasket;

namespace FreeCourse.Services.Basket.Aplication.Services.Features.BasketFeature.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.Basket, CreateOrUpdateCommandRequest>().ReverseMap();
            CreateMap<Domain.Entities.Basket, CreateOrUpdateCommandResponse>().ReverseMap();
        }
    }
}
