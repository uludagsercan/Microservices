using Application.Services.Features.DiscountFeature.Commands.CreateDiscount;
using Application.Services.Features.DiscountFeature.Commands.DeleteDiscount;
using Application.Services.Features.DiscountFeature.Commands.UpdateDiscount;
using Application.Services.Features.DiscountFeature.Queries.GetAllDiscounts;
using Application.Services.Features.DiscountFeature.Queries.GetDiscountByCodeAndUserId;
using Application.Services.Features.DiscountFeature.Queries.GetDiscountById;
using FreeCourse.Shared.BaseController;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Services.DiscountAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DiscountsController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public DiscountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscount([FromBody] CreateDiscountCommandRequest createDiscountCommandRequest)
        {
            var response = await _mediator.Send(request: createDiscountCommandRequest);
            return CreateActionResultInstance(response);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteDiscount([FromRoute] DeleteDiscountCommandRequest deleteDiscountCommandRequest)
        {
            var response = await _mediator.Send(request: deleteDiscountCommandRequest);
            return CreateActionResultInstance(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscount([FromBody] UpdateDiscountCommandRequest updateDiscountCommandRequest)
        {
            var response = await _mediator.Send(updateDiscountCommandRequest);
            return CreateActionResultInstance(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDiscounts(GetAllDiscountQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return CreateActionResultInstance(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetDiscountById([FromRoute]GetDiscountByIdQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return CreateActionResultInstance(response);
        }
        [HttpGet("{Code}/{UserId}")]
        public async Task<IActionResult> GetDiscountByCodeAndUserId([FromRoute] GetDiscountByCodeAndUserIdQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return CreateActionResultInstance(response);
        }
    }
}
