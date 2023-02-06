using Catalog.Domain.Entities;
using FreeCourse.Shared.Dtos;

namespace Catalog.Application.Services.Features.CourseFeature.Queries.GetCourseById
{
    public class GetByIdCourseQueryResponse
    {
        public ResponseDto<Course> Response { get; set; }
    }
}
