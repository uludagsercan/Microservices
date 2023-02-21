using Application.Repositories.Discount;
using AutoMapper;
using Domain.Entities;
using FreeCourse.Shared.Dtos;
using MediatR;

namespace Application.Services.Features.DiscountFeature.Commands.CreateDiscount
{
    public class CreateDiscountCommandHandler : IRequestHandler<CreateDiscountCommandRequest, CreateDiscountCommandResponse>
    {
        private readonly IDiscountWriteRepository _discountWriteRepository;
        private readonly IMapper _mapper;
     

        public CreateDiscountCommandHandler(IDiscountWriteRepository discountWriteRepository, IMapper mapper)
        {
            _discountWriteRepository = discountWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateDiscountCommandResponse> Handle(CreateDiscountCommandRequest request, CancellationToken cancellationToken)
        {
            string sqlQuery = $"INSERT INTO discount (id,userid,rate,code) VALUES(@Id,@UserId,@Rate,@Code)";
            var mappedDiscount = _mapper.Map<Discount>(request);
            mappedDiscount.Id = new Guid().ToString();
            //mappedDiscount.CreatedTime = DateTime.UtcNow;
            var result =await _discountWriteRepository.SaveAsync(sqlQuery, mappedDiscount);
            return new()
            {
               Response= ResponseDto<NoContent>.Success(204)
            };
        }
    }
}
