using Catalog.Domain.Entities;
using FreeCourse.Shared.Dtos;

namespace Catalog.Application.Services.Features.CategoryFeature.Commands.UpdateCategory
{
    public class UpdateCategoryCommandResponse
    {
        public ResponseDto<Category> Response { get; set; }
    }
}
