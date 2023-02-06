using Catalog.Domain.Entities;
using FreeCourse.Shared.Dtos;

namespace Catalog.Application.Services.Features.CourseFeature.Commands.CreateCourse
{
    public class CreateCourseCommandResponse
    {
        public ResponseDto<Course> Response { get; set; }
    }
}
