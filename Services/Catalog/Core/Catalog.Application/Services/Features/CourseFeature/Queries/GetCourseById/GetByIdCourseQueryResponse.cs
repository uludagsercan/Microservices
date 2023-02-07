using Catalog.Application.Services.Features.CourseFeature.Dtos.GetCourseByIdWithCategory;
using FreeCourse.Shared.Dtos;

namespace Catalog.Application.Services.Features.CourseFeature.Queries.GetCourseById
{
    public class GetByIdCourseQueryResponse
    {
        public ResponseDto<GetCourseByIdWtihCategoryQueryResponseDto> Response { get; set; }
    }
}
