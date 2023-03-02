using AutoMapper;
using Catalog.Application.Services.Repositories.CourseRepository;
using Catalog.Domain.Entities;
using FreeCourse.Shared.Messages;
using MediatR;

namespace Catalog.Application.Services.Features.CourseFeature.Commands.UpdateCourse
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommandRequest, UpdateCourseCommandResponse>
    {
        private readonly ICourseWriteRepository _courseWriteRepository;
        private readonly MassTransit.IPublishEndpoint _publishEndpoint;
        private readonly IMapper _mapper;

        public UpdateCourseCommandHandler(ICourseWriteRepository courseWriteRepository, IMapper mapper, MassTransit.IPublishEndpoint publishEndpoint)
        {
            _courseWriteRepository = courseWriteRepository;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<UpdateCourseCommandResponse> Handle(UpdateCourseCommandRequest request, CancellationToken cancellationToken)
        {
            var course = _mapper.Map<Course>(request);
            var updatedResult = _courseWriteRepository.Update(course);
            if (updatedResult)
            {
                
                await _publishEndpoint.Publish(new CreateNameChangedEvent()
                {
                    CourseId = course.Id,
                    UpdatedName = course.CourseName
                });
                return new() { Response = new() { Data = course, IsSuccessful = true, StatusCode = 200 } };

            }
            return new() { Response = new() { IsSuccessful = false, Data = course, StatusCode = 400, Errors = new List<string> { "Update Unsuccessful" } } };
        }
    }
}
