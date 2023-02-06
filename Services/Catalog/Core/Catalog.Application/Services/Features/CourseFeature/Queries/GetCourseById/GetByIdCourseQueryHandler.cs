using Catalog.Application.Services.Repositories.CourseRepository;
using MediatR;

namespace Catalog.Application.Services.Features.CourseFeature.Queries.GetCourseById
{
    public class GetByIdCourseQueryHandler : IRequestHandler<GetByIdCourseQueryRequest, GetByIdCourseQueryResponse>
    {
        private readonly ICourseReadRepository _courseReadRepository;

        public GetByIdCourseQueryHandler(ICourseReadRepository courseReadRepository)
        {
            _courseReadRepository = courseReadRepository;
        }

        public async Task<GetByIdCourseQueryResponse> Handle(GetByIdCourseQueryRequest request, CancellationToken cancellationToken)
        {
            var course = await _courseReadRepository.GetSingleAsync(x => x.Id == request.Id);
            if (course != null)
                return new() { Response = new() { Data = course, IsSuccessful = true, StatusCode = 200 } };
            return new() { Response = new() { Errors = new List<string>() { "Course Not Found" }, IsSuccessful = false, StatusCode = 400 } };
        }
    }
}
