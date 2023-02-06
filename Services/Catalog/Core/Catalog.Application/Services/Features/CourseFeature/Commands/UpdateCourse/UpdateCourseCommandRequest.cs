using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.Application.Services.Features.CourseFeature.Commands.UpdateCourse
{
    public class UpdateCourseCommandRequest:IRequest<UpdateCourseCommandResponse>
    {
        public string Id { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public decimal Price { get; set; }
        public string UserId { get; set; }
        public string Picture { get; set; }
        public DateTime CreatedDate { get; set; }
        public Feature Feature { get; set; }
        public string CategoryId { get; set; }
    }
}
