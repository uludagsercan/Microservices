using Catalog.Application.Settings;
using Catalog.Domain.Entities;
using Catalog.Application.Services.Repositories.CourseRepository;
using Persistence.Contexts;
using MongoDB.Driver;


namespace Persistence.Repositories.CourseRepository
{
    public class CourseReadRepository : ReadRepository<Course>, ICourseReadRepository
    {
        private readonly IDatabaseSettings _databaseSetting;
        public CourseReadRepository(IDatabaseSettings databaseSettings) : base(databaseSettings)
        {
            _databaseSetting = databaseSettings;
        }

        public ICollection<Course> GetAllCoursesWithCategory()
        {
            using var context = new MongoDBCatalogContext(_databaseSetting);

            var coursesWithCategory = (from course in context.GetCollection<Course>().AsQueryable()
                                       join category in context.GetCollection<Category>().AsQueryable()
                                       on course.CategoryId equals category.Id into joined
                                       select new { course, joined }
                                      ).ToList();
            List<Course> courses = new();
            foreach (var item in coursesWithCategory)
            {
                courses.Add(new()
                {
                    Category = item.joined.SingleOrDefault(),
                    CourseDescription = item.course.CourseDescription,
                    CourseName = item.course.CourseName,
                    CreatedDate = item.course.CreatedDate,
                    Feature = item.course.Feature,
                    Id = item.course.Id,
                    Picture= item.course.Picture,
                    Price=item.course.Price,
                    UserId = item.course.UserId,
                    CategoryId= item.course.CategoryId
                });
            }

            return courses;

        }

        public Course GetCourseByIdWithCategory(string id)
        {
            using var context = new MongoDBCatalogContext(_databaseSetting);
            var coursesWithCategory = (from course in context.GetCollection<Course>().AsQueryable()
                                       join category in context.GetCollection<Category>().AsQueryable()
                                       on course.CategoryId equals category.Id into joined
                                       where course.Id == id
                                       select new { course, joined }

                                  ).ToList();

            Course courseWithCategory = new();
            foreach (var item in coursesWithCategory)
            {
                courseWithCategory = item.course;
                courseWithCategory.Category = item.joined.SingleOrDefault();
            }
            return courseWithCategory;
        }
    }
}
