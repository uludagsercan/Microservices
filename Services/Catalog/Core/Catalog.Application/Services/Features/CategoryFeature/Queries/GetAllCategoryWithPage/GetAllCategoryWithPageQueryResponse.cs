using Catalog.Domain.Entities;
using FreeCourse.Shared.Dtos;

namespace Catalog.Application.Services.Features.CategoryFeature.Queries.GetAllCategoryWithPage
{
    public class GetAllCategoryWithPageQueryResponse
    {
        public long TotalItem { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public ResponseDto<List<Category>> Response { get; set; }
    }
}
