using Catalog.Domain.Entities;
using FreeCourse.Shared.Repositories;

namespace Catalog.Application.Services.Repositories.CourseRepository
{
    public interface ICourseReadRepository:IReadRepository<Course>
    {
    }
}
