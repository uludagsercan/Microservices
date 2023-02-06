using MediatR;

namespace Catalog.Application.Services.Features.CourseFeature.Queries.GetCourseById
{
    public class GetByIdCourseQueryRequest:IRequest<GetByIdCourseQueryResponse>
    {
        public string Id { get; set; }
    }
}
