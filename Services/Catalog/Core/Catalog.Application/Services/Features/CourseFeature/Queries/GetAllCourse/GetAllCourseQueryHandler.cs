using AutoMapper;
using Catalog.Application.Services.Features.CourseFeature.Dtos.GetAllCourse;
using Catalog.Application.Services.Repositories.CourseRepository;
using MediatR;
using MongoDB.Driver;
using System.Linq;

namespace Catalog.Application.Services.Features.CourseFeature.Queries.GetAllCourse
{
    public class GetAllCourseQueryHandler : IRequestHandler<GetAllCourseQueryRequest, GetAllCourseQueryResponse>
    {
        private readonly ICourseReadRepository _courseReadRepository;

        private readonly IMapper _mapper;


        public GetAllCourseQueryHandler(ICourseReadRepository courseReadRepository, IMapper mapper)
        {
            _courseReadRepository = courseReadRepository;
            _mapper = mapper;
        }

        public async Task<GetAllCourseQueryResponse> Handle(GetAllCourseQueryRequest request, CancellationToken cancellationToken)
        {
            var courses = _courseReadRepository.GetAllCoursesWithCategory();
            var mappedCourses = _mapper.Map<ICollection<GetAllCourseQueryResponseDto>>(courses);
            if (courses.Any())
            {
                return new() { Response = new() { Data = mappedCourses, IsSuccessful = true, StatusCode = 200 } };
            }
            return new() { Response = new() { Errors = new() { "Course Not Found" }, StatusCode = 400, IsSuccessful = false } };
        }
    }
}
