using AutoMapper;
using Catalog.Application.Services.Features.CourseFeature.Dtos.GetCourseByIdWithCategory;
using Catalog.Application.Services.Repositories.CourseRepository;
using MediatR;

namespace Catalog.Application.Services.Features.CourseFeature.Queries.GetCourseById
{
    public class GetByIdCourseQueryHandler : IRequestHandler<GetByIdCourseQueryRequest, GetByIdCourseQueryResponse>
    {
        private readonly ICourseReadRepository _courseReadRepository;
        private readonly IMapper _mapper;

        public GetByIdCourseQueryHandler(ICourseReadRepository courseReadRepository, IMapper mapper)
        {
            _courseReadRepository = courseReadRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdCourseQueryResponse> Handle(GetByIdCourseQueryRequest request, CancellationToken cancellationToken)
        {
            var course = _courseReadRepository.GetCourseByIdWithCategory(request.Id);
            var mappedCourse = _mapper.Map<GetCourseByIdWtihCategoryQueryResponseDto>(course);
            if (course != null)
                return new() { Response = new() { Data = mappedCourse, IsSuccessful = true, StatusCode = 200 } };
            return new() { Response = new() { Errors = new List<string>() { "Course Not Found" }, IsSuccessful = false, StatusCode = 400 } };
        }
    }
}
