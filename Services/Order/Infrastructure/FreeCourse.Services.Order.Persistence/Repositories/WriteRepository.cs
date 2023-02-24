using FreeCourse.Services.Order.Application.Repositories;
using FreeCourse.Services.Order.Domain.Core;
using FreeCourse.Services.Order.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FreeCourse.Services.Order.Persistence.Repositories
{
    public class WriteRepository<TEntity> : IWriteRepository<TEntity> where TEntity : Entity
    {
        private readonly OrderRepositoryContext _context;

        public WriteRepository(OrderRepositoryContext context)
        {
            _context = context;
          
        }
        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public async Task<bool> CreateAsync(TEntity entity)
        {
            var entryEntity = await Table.AddAsync(entity);
            return entryEntity.State == EntityState.Added;
        }

        public  bool Update(TEntity entity)
        {
            var entryEntity =  Table.Update(entity);
            
            return entryEntity.State == EntityState.Modified;
        }

       public async Task<bool> Remove(int id)
        {
            var entity = await Table.FirstOrDefaultAsync(data => data.Id == id);
            var entryState = Table.Remove(entity);
            return entryState.State == EntityState.Deleted;
        }
        public async Task SaveChangeAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
