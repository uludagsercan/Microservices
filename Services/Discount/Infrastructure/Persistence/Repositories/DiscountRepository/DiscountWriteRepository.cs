using Application.Repositories.Discount;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.DiscountRepository
{
    public class DiscountWriteRepository : WriteRepository<Discount>, IDiscountWriteRepository
    {
        public DiscountWriteRepository(DiscountRepositoryContext context) : base(context)
        {
        }
    }
}
