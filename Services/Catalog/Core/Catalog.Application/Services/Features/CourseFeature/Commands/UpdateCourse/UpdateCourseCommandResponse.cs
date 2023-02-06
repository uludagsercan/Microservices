using Catalog.Domain.Entities;
using FreeCourse.Shared.Dtos;

namespace Catalog.Application.Services.Features.CourseFeature.Commands.UpdateCourse
{
    public class UpdateCourseCommandResponse
    {
        public ResponseDto<Course> Response { get; set; }
    }
}
