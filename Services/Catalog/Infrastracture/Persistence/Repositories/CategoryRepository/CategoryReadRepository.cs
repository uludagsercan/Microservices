using Catalog.Application.Services.Repositories.CategoryRepository;
using Catalog.Application.Settings;
using Catalog.Domain.Entities;

namespace Persistence.Repositories.CategoryRepository
{
    public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
    {
        public CategoryReadRepository(IDatabaseSettings databaseSettings) : base(databaseSettings)
        {
        }
    }
}
