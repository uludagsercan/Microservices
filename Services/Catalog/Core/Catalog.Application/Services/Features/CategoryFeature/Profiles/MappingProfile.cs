using AutoMapper;
using Catalog.Application.Services.Features.CategoryFeature.Commands.CreateCategory;
using Catalog.Application.Services.Features.CategoryFeature.Commands.UpdateCategory;
using Catalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Services.Features.CategoryFeature.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CreateCategoryCommandRequest>().ReverseMap();
            CreateMap<Category, CreateCategoryCommandResponse>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommandRequest>().ReverseMap();
        }
    }
}
