using Catalog.Application.Services.Repositories.CourseRepository;
using MediatR;

namespace Catalog.Application.Services.Features.CourseFeature.Commands.DeleteCourse
{
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommandRequest, DeleteCourseCommandResponse>
    {
        private readonly ICourseWriteRepository _courseWriteRepository;

        public DeleteCourseCommandHandler(ICourseWriteRepository courseWriteRepository)
        {
            _courseWriteRepository = courseWriteRepository;
        }

        public async Task<DeleteCourseCommandResponse> Handle(DeleteCourseCommandRequest request, CancellationToken cancellationToken)
        {
            var deletedResult =await _courseWriteRepository.RemoveAsync(request.Id);
            if (deletedResult)
                return new DeleteCourseCommandResponse() { Response = new() { IsSuccessful = true, StatusCode = 200 } };
            return new() { Response = new() { IsSuccessful = false, StatusCode = 400, Errors = new() { "Deletion Unsuccussful" } } };
        }
    }
}
