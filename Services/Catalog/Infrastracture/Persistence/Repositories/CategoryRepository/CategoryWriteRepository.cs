using Catalog.Application.Services.Repositories.CategoryRepository;
using Catalog.Application.Settings;
using Catalog.Domain.Entities;

namespace Persistence.Repositories.CategoryRepository
{
    public class CategoryWriteRepository : WriteRepository<Category>, ICategoryWriteRepository
    {
        public CategoryWriteRepository(IDatabaseSettings databaseSettings) : base(databaseSettings)
        {
        }
    }
}
