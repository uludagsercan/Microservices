using AutoMapper;
using Catalog.Application.Services.Repositories.CategoryRepository;
using Catalog.Domain.Entities;
using FreeCourse.Shared.Dtos;
using MediatR;

namespace Catalog.Application.Services.Features.CategoryFeature.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {
        private readonly ICategoryWriteRepository _categoryWriteRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository, IMapper mapper)
        {
            _categoryWriteRepository = categoryWriteRepository;
            _mapper = mapper;
        }

        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var mapperCategory = _mapper.Map<Category>(request);
            var result = _categoryWriteRepository.Update(mapperCategory);
            if (result)
                return new UpdateCategoryCommandResponse() { Response = ResponseDto<Category>.Success(mapperCategory, 200) };
            return new UpdateCategoryCommandResponse() { Response = ResponseDto<Category>.Fail(new List<string> { "Update UnSuccessful"}, 400) };

        }
    }
}
