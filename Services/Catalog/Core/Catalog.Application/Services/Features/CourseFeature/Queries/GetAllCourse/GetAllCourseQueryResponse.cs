using Catalog.Domain.Entities;
using FreeCourse.Shared.Dtos;

namespace Catalog.Application.Services.Features.CourseFeature.Queries.GetAllCourse
{
    public class GetAllCourseQueryResponse
    {
        public ResponseDto<ICollection<Course>> Response { get; set; }
    }
}
