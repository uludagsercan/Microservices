using Catalog.Application.Services.Repositories.CategoryRepository;
using Catalog.Domain.Entities;
using FreeCourse.Shared.Dtos;
using MediatR;

namespace Catalog.Application.Services.Features.CategoryFeature.Queries.GetAllCategoryWithPage
{
    internal class GetAllCategoryWithPageQueryHandler : IRequestHandler<GetAllCategoryWtihPageQueryRequest, GetAllCategoryWithPageQueryResponse>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;

        public GetAllCategoryWithPageQueryHandler(ICategoryReadRepository categoryReadRepository)
        {
            _categoryReadRepository = categoryReadRepository;
        }

        public async Task<GetAllCategoryWithPageQueryResponse> Handle(GetAllCategoryWtihPageQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = _categoryReadRepository.GetAll().Skip(request.Page * request.PageSize).Take(request.PageSize).ToList();
            var total = _categoryReadRepository.GetAll().LongCount();

            return new GetAllCategoryWithPageQueryResponse()
            {
                Page = request.Page,
                PageSize = request.PageSize,
                TotalItem = total,
                Response = ResponseDto<List<Category>>.Success(categories, 200)
            };
        }
    }
}
