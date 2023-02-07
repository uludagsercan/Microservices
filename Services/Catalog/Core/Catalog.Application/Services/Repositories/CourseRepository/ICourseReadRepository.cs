using Catalog.Domain.Entities;
using FreeCourse.Shared.Repositories;

namespace Catalog.Application.Services.Repositories.CourseRepository
{
    public interface ICourseReadRepository:IMongoDBReadRepository<Course>
    {
        ICollection<Course> GetAllCoursesWithCategory();
        Course GetCourseByIdWithCategory(string id);
    }
}
