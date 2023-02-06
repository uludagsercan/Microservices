using Catalog.Application.Services.Repositories.CourseRepository;
using Catalog.Application.Settings;
using Catalog.Domain.Entities;

namespace Persistence.Repositories.CourseRepository
{
    public class CourseWriteRepository : WriteRepository<Course>,ICourseWriteRepository
    {
        public CourseWriteRepository(IDatabaseSettings databaseSettings) : base(databaseSettings)
        {
        }
    }
}
