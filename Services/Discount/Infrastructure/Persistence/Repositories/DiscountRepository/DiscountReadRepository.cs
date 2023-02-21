using Application.Repositories.Discount;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.DiscountRepository
{
    public class DiscountReadRepository : ReadRepository<Discount>, IDiscountReadRepository
    {
        public DiscountReadRepository(DiscountRepositoryContext context) : base(context)
        {
        }
    }
}
