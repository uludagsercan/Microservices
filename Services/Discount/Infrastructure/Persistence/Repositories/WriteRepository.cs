using Application.Repositories;
using FreeCourse.Shared.Entities.Commons;
using Persistence.Contexts;
using Dapper;

namespace Persistence.Repositories
{
    public class WriteRepository<TEntity> : IWriteRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private readonly DiscountRepositoryContext _context;

        public WriteRepository(DiscountRepositoryContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveAsync(string query, object entity)
        {
            var status =await _context.GetConnection().ExecuteAsync(query, entity);
            if (status > 0)
                return true;
            return false;
        }

        public async Task<bool> DeleteAsync(string query,  object param)
        {
            var status = await _context.GetConnection().ExecuteAsync(query,param);
            if (status > 0)
                return true;
            return false;
        }

     
    }
}
