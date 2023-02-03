using MediatR;

namespace Catalog.Application.Services.Features.CategoryFeature.Commands.CreateCategory
{
    public class CreateCategoryCommandRequest : IRequest<CreateCategoryCommandResponse>
    {
        public string Name { get; set; }
    }
}
