using FreeCourse.Services.Basket.Aplication.Services.Features.BasketFeature.Commands.CreateOrUpdateBasket;
using FreeCourse.Services.Basket.Aplication.Services.Features.BasketFeature.Commands.DeleteBasket;
using FreeCourse.Services.Basket.Aplication.Services.Features.BasketFeature.Queries.GetBasket;
using FreeCourse.Shared.BaseController;
using FreeCourse.Shared.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Services.BasketAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BasketsController : CustomBaseController
    {
        private readonly IMediator _mediator;
     

        public BasketsController(IMediator mediator)
        {
            _mediator = mediator;
     
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate([FromBody]CreateOrUpdateCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return CreateActionResultInstance(response);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] DeleteBasketCommandRequest request)
        {
        
            var response = await _mediator.Send(request);
            return CreateActionResultInstance(response);
        }
        [HttpGet]
        public async Task<IActionResult> GetBasket([FromRoute]GetBasketQueryRequest request)
        {
          
            var response = await _mediator.Send(request);
            return CreateActionResultInstance(response);
        }
    }
}
