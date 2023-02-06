using Catalog.Domain.Entities;
using FreeCourse.Shared.Dtos;

namespace Catalog.Application.Services.Features.CourseFeature.Queries.GetAllCourseWithPage
{
    public class GetAllCourseWithPageQueryResponse
    {
        public long TotalItem { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public ResponseDto<ICollection<Course>> Response { get; set; }
    }
}
