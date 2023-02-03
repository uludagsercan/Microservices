using MediatR;

namespace Catalog.Application.Services.Features.CategoryFeature.Commands.UpdateCategory
{
    public class UpdateCategoryCommandRequest:IRequest<UpdateCategoryCommandResponse>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
