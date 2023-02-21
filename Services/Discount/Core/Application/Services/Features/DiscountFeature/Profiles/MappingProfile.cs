using Application.Services.Features.DiscountFeature.Commands.CreateDiscount;
using Application.Services.Features.DiscountFeature.Commands.UpdateDiscount;
using AutoMapper;
using Domain.Entities;

namespace Application.Services.Features.DiscountFeature.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Discount, CreateDiscountCommandRequest>().ReverseMap();
            CreateMap<Discount, UpdateDiscountCommandRequest>().ReverseMap();
        }
    }
}
