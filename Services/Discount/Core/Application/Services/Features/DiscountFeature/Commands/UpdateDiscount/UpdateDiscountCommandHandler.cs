using Application.Repositories.Discount;
using AutoMapper;
using Domain.Entities;
using FreeCourse.Shared.Dtos;
using MediatR;

namespace Application.Services.Features.DiscountFeature.Commands.UpdateDiscount
{
    public class UpdateDiscountCommandHandler : IRequestHandler<UpdateDiscountCommandRequest, UpdateDiscountCommandResponse>
    {
        private readonly IDiscountWriteRepository _discountWriteRepository;
        private readonly IMapper _mapper;

        public UpdateDiscountCommandHandler(IDiscountWriteRepository discountWriteRepository, IMapper mapper)
        {
            _discountWriteRepository = discountWriteRepository;
            _mapper = mapper;
        }

        public async Task<UpdateDiscountCommandResponse> Handle(UpdateDiscountCommandRequest request, CancellationToken cancellationToken)
        {
            var sqlQuery = $"UPDATE discount SET @userid=UserId,@rate=Rate,@code=Code WHERE @id=Id";
            var mappedDiscount = _mapper.Map<Discount>(request);
            var result = await _discountWriteRepository.SaveAsync(sqlQuery, mappedDiscount);
            return new()
            {
                Response = ResponseDto<NoContent>.Success(204)
            };
        }
    }
}
