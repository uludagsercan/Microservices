
using MediatR;

namespace Catalog.Application.Services.Features.CourseFeature.Queries.GetAllCourseWithPage
{
    public class GetAllCourseWithPageQueryRequest:IRequest<GetAllCourseWithPageQueryResponse>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
