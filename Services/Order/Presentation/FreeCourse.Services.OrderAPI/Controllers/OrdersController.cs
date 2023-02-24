using FreeCourse.Services.Order.Application.Features.OrderFeature.Commands.CreateOrder;
using FreeCourse.Services.Order.Application.Features.OrderFeature.Queries.GetOrdersByUserId;
using FreeCourse.Shared.BaseController;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Services.OrderAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody]CreateOrderCommandRequest createOrderCommandRequest)
        {
            var response =await _mediator.Send(createOrderCommandRequest);
            return CreateActionResultInstance(response);
        }
        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetOrdersByUserId([FromRoute] GetOrdersByUserIdQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return CreateActionResultInstance(response);
        }
    }
}
