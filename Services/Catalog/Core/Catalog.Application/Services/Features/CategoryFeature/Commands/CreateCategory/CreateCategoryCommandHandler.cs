using AutoMapper;
using Catalog.Application.Services.Repositories.CategoryRepository;
using Catalog.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Application.Services.Features.CategoryFeature.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
    {
        private readonly ICategoryWriteRepository _categoryWriteRepository;
        private readonly IMapper _mapper;
        public CreateCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository, IMapper mapper)
        {
            _categoryWriteRepository = categoryWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var mapperCategory = _mapper.Map<Category>(request);
            await _categoryWriteRepository.AddAsync(mapperCategory);
            return new SuccessCreateCategoryCommadResponse() { IsSuccessful = true, Name = mapperCategory.Name, StatusCode = 200 };
        }
    }
}
