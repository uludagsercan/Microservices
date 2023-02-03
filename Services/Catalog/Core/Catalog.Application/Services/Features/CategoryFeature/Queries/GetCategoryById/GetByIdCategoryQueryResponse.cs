using Catalog.Domain.Entities;
using FreeCourse.Shared.Dtos;

namespace Catalog.Application.Services.Features.CategoryFeature.Queries.GetCategoryById
{
    public class GetByIdCategoryQueryResponse
    {
        public ResponseDto<Category> Response { get; set; }
    }
}
