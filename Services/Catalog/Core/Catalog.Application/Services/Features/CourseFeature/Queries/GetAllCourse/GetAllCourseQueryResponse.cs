using Catalog.Application.Services.Features.CourseFeature.Dtos.GetAllCourse;
using Catalog.Domain.Entities;
using FreeCourse.Shared.Dtos;

namespace Catalog.Application.Services.Features.CourseFeature.Queries.GetAllCourse
{
    public class GetAllCourseQueryResponse
    {
        public ResponseDto<ICollection<GetAllCourseQueryResponseDto>> Response { get; set; }
    }
}
