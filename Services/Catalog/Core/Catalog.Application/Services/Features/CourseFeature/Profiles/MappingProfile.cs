using AutoMapper;
using Catalog.Application.Services.Features.CourseFeature.Commands.CreateCourse;
using Catalog.Application.Services.Features.CourseFeature.Commands.UpdateCourse;
using Catalog.Domain.Entities;

namespace Catalog.Application.Services.Features.CourseFeature.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, UpdateCourseCommandRequest>().ReverseMap();
            CreateMap<Course, CreateCourseCommandRequest>().ReverseMap();
        }
    }
}
