using MediatR;

namespace Catalog.Application.Services.Features.CategoryFeature.Queries.GetCategoryById
{
    public class GetByIdCategoryQueryRequest:IRequest<GetByIdCategoryQueryResponse>
    {
        public string Id { get; set; }
    }
}
