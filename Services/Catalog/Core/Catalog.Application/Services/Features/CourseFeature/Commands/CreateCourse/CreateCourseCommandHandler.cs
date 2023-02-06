using AutoMapper;
using Catalog.Application.Services.Repositories.CourseRepository;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.Application.Services.Features.CourseFeature.Commands.CreateCourse
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommandRequest, CreateCourseCommandResponse>
    {
        private readonly ICourseWriteRepository _courseWriteRepository;
        private readonly IMapper _mapper;

        public CreateCourseCommandHandler(ICourseWriteRepository courseWriteRepository, IMapper mapper)
        {
            _courseWriteRepository = courseWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateCourseCommandResponse> Handle(CreateCourseCommandRequest request, CancellationToken cancellationToken)
        {
            var course = _mapper.Map<Course>(request);
            await _courseWriteRepository.AddAsync(course);
            return new() { Response = new() { Data = course, IsSuccessful = true, StatusCode = 200 } };
          
        }
    }
}
