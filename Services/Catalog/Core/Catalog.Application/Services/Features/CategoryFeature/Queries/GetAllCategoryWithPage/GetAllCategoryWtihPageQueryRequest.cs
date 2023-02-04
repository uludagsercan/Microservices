using MediatR;

namespace Catalog.Application.Services.Features.CategoryFeature.Queries.GetAllCategoryWithPage
{
    public class GetAllCategoryWtihPageQueryRequest:IRequest<GetAllCategoryWithPageQueryResponse>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
