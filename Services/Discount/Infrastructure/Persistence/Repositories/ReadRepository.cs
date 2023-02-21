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

        public async Task<IEnumerable<TEntity>> GetWhere(string query,object param = null)
        {
            if(param != null)
            {
                var result = await _context.GetConnection().QueryAsync<TEntity>(query,param);
                return result;
            }
            else
            {
                var result = await _context.GetConnection().QueryAsync<TEntity>(query);
                return result;
            }
         
        }

        public async Task<TEntity> GetSingleAsync(string query,object param)
        {
            var result = await _context.GetConnection().QueryAsync<TEntity>(query,param);
            return result.SingleOrDefault();
        }
    }
}
