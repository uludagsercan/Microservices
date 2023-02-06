using Catalog.Application.Settings;
using Catalog.Domain.Entities;
using Catalog.Application.Services.Repositories.CourseRepository;

namespace Persistence.Repositories.CourseRepository
{
    public class CourseReadRepository : ReadRepository<Course>, ICourseReadRepository
    {
        public CourseReadRepository(IDatabaseSettings databaseSettings) : base(databaseSettings)
        {
        }
    }
}
