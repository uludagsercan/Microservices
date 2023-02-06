using Catalog.Domain.Entities;
using FreeCourse.Shared.Dtos;

namespace Catalog.Application.Services.Features.CourseFeature.Commands.DeleteCourse
{
    public class DeleteCourseCommandResponse
    {
       public ResponseDto<Course> Response { get; set; }
    }
}
