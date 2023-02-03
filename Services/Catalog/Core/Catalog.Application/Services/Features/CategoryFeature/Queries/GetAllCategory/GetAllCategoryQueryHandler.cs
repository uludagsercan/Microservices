using Catalog.Application.Services.Repositories.CategoryRepository;
using Catalog.Domain.Entities;
using FreeCourse.Shared.Dtos;
using MediatR;

namespace Catalog.Application.Services.Features.CategoryFeature.Queries.GetAllCategory
{
    internal class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, GetAllCategoryQueryResponse>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;

        public GetAllCategoryQueryHandler(ICategoryReadRepository categoryReadRepository)
        {
            _categoryReadRepository = categoryReadRepository;
        }

        public async Task<GetAllCategoryQueryResponse> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = _categoryReadRepository.GetAll().ToList();
            return new GetAllCategoryQueryResponse() { Response = ResponseDto<List<Category>>.Success(categories, 200) };
        }
    }
}
