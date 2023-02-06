using AutoMapper;
using Catalog.Application.Services.Repositories.CourseRepository;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.Application.Services.Features.CourseFeature.Commands.UpdateCourse
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommandRequest, UpdateCourseCommandResponse>
    {
        private readonly ICourseWriteRepository _courseWriteRepository;
        private readonly IMapper _mapper;

        public UpdateCourseCommandHandler(ICourseWriteRepository courseWriteRepository, IMapper mapper)
        {
            _courseWriteRepository = courseWriteRepository;
            _mapper = mapper;
        }

        public async Task<UpdateCourseCommandResponse> Handle(UpdateCourseCommandRequest request, CancellationToken cancellationToken)
        {
            var course = _mapper.Map<Course>(request);
            var updatedResult = _courseWriteRepository.Update(course);
            if (updatedResult)
                return new() { Response = new() { Data = course, IsSuccessful = true, StatusCode = 200 } };
            return new() { Response = new() { IsSuccessful = false, Data = course, StatusCode = 400, Errors = new List<string> { "Update Unsuccessful" } } };
        }
    }
}
