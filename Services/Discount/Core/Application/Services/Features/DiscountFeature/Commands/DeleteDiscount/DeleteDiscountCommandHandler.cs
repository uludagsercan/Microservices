using Application.Repositories.Discount;
using Domain.Entities;
using FreeCourse.Shared.Dtos;
using MediatR;

namespace Application.Services.Features.DiscountFeature.Commands.DeleteDiscount
{
    public class DeleteDiscountCommandHandler : IRequestHandler<DeleteDiscountCommandRequest, DeleteDiscountCommandResponse>
    {
        private readonly IDiscountWriteRepository _discountWriteRepository;

        public DeleteDiscountCommandHandler(IDiscountWriteRepository discountWriteRepository)
        {
            _discountWriteRepository = discountWriteRepository;
        }

        public async Task<DeleteDiscountCommandResponse> Handle(DeleteDiscountCommandRequest request, CancellationToken cancellationToken)
        {
            string sqlQuery = $"Delete From discount where id=@Id";
            var result = await _discountWriteRepository.DeleteAsync(sqlQuery, new { Id = request.Id });

            return new()
            {
                Resposne = ResponseDto<NoContent>.Success(204)
            };
        }
    }
}
