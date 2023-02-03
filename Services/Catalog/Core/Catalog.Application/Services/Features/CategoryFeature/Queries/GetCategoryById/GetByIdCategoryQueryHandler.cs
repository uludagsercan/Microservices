using AutoMapper;
using Catalog.Application.Services.Repositories.CategoryRepository;
using Catalog.Domain.Entities;
using FreeCourse.Shared.Dtos;
using MediatR;

namespace Catalog.Application.Services.Features.CategoryFeature.Queries.GetCategoryById
{
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQueryRequest, GetByIdCategoryQueryResponse>
    {
        private readonly ICategoryReadRepository _categoryReadRepository;

        public GetByIdCategoryQueryHandler(ICategoryReadRepository categoryReadRepository, IMapper mapper)
        {
            _categoryReadRepository = categoryReadRepository;
        }

        public async Task<GetByIdCategoryQueryResponse> Handle(GetByIdCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var categoryResult =await _categoryReadRepository.GetSingleAsync(x=> x.Id == request.Id);
            if (categoryResult == null)
                return new GetByIdCategoryQueryResponse() { Response = ResponseDto<Category>.Fail( "Category Not Found", 404) };
            return new GetByIdCategoryQueryResponse() { Response = ResponseDto<Category>.Success(categoryResult, 200) };

        }
    }
}
