using Catalog.Application.Services.Repositories.CourseRepository;
using MediatR;

namespace Catalog.Application.Services.Features.CourseFeature.Queries.GetAllCourseWithPage
{
    public class GetAllCourseWithPageQueryHandler : IRequestHandler<GetAllCourseWithPageQueryRequest, GetAllCourseWithPageQueryResponse>
    {
        private readonly ICourseReadRepository _courseReadRepository;

        public GetAllCourseWithPageQueryHandler(ICourseReadRepository courseReadRepository)
        {
            _courseReadRepository = courseReadRepository;
        }

        public async Task<GetAllCourseWithPageQueryResponse> Handle(GetAllCourseWithPageQueryRequest request, CancellationToken cancellationToken)
        {
            var courses = _courseReadRepository.GetAll().Skip(request.Page * request.PageSize).Take(request.PageSize).ToList();
            var totalItem = _courseReadRepository.GetAll().LongCount();
            if (courses.Any())
                return new() { Page = request.Page, PageSize = request.PageSize, TotalItem = totalItem, Response = new() { Data = courses, IsSuccessful = false, StatusCode = 200 } };
            return new() { Page = request.Page, PageSize = request.PageSize, TotalItem = totalItem, Response = new() { Errors = new() { "Course Not Found" }, IsSuccessful = false, StatusCode = 400 } };
        }
    }
}
