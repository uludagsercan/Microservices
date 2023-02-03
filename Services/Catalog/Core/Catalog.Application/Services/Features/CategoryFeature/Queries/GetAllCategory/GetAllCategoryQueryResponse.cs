using Catalog.Domain.Entities;
using FreeCourse.Shared.Dtos;

namespace Catalog.Application.Services.Features.CategoryFeature.Queries.GetAllCategory
{
    public class GetAllCategoryQueryResponse
    {
        public ResponseDto<List<Category>> Response { get; set; }
    }
}
