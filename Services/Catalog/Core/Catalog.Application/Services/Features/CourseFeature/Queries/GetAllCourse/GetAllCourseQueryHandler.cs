using Catalog.Application.Services.Repositories.CourseRepository;
using MediatR;

namespace Catalog.Application.Services.Features.CourseFeature.Queries.GetAllCourse
{
    public class GetAllCourseQueryHandler : IRequestHandler<GetAllCourseQueryRequest, GetAllCourseQueryResponse>
    {
        private readonly ICourseReadRepository _courseReadRepository;

        public GetAllCourseQueryHandler(ICourseReadRepository courseReadRepository)
        {
            _courseReadRepository = courseReadRepository;
        }

        public async Task<GetAllCourseQueryResponse> Handle(GetAllCourseQueryRequest request, CancellationToken cancellationToken)
        {
            var courses = _courseReadRepository.GetAll();
            if (courses.Any())
            {
                return new() { Response = new() { Data = courses.ToList(), IsSuccessful = true, StatusCode = 200 } };
            }
            return new() { Response = new() { Errors = new() { "Course Not Found" }, StatusCode = 400, IsSuccessful = false } };
        }
    }
}
