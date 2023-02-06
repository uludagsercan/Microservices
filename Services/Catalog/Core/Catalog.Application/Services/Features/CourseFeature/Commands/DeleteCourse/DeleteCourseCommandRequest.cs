using MediatR;

namespace Catalog.Application.Services.Features.CourseFeature.Commands.DeleteCourse
{
    public class DeleteCourseCommandRequest:IRequest<DeleteCourseCommandResponse>
    {
        public string Id { get; set; }
    }
}
