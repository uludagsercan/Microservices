using Application.Repositories;
using Dapper;
using FreeCourse.Shared.Entities.Commons;
using Persistence.Contexts;
using System.Text;

namespace Persistence.Repositories
{
    public class ReadRepository<TEntity> :IReadRepository<TEntity> where TEntity: class,IEntity,new()
    {

        private readonly DiscountRepositoryContext _context;

        public ReadRepository(DiscountRepositoryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(string query)
        {
            var result = await _context.GetConnection().QueryAsync<TEntity>(query);
            return result;
        }

        public async Task<TEntity> GetWhere(string query)
        {
            var result = await _context.GetConnection().QueryAsync<TEntity>(query);
            return result.FirstOrDefault();
        }
    }
}
