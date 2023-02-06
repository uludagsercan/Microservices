using Catalog.Domain.Entities;
using FreeCourse.Shared.Repositories;

namespace Catalog.Application.Services.Repositories.CourseRepository
{
    public interface ICourseWriteRepository : IWriteRepository<Course>
    {
    }
}
