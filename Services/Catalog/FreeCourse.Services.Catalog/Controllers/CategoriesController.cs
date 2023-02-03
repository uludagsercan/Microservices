using Catalog.Application.Services.Features.CategoryFeature.Commands.CreateCategory;
using Catalog.Application.Services.Features.CategoryFeature.Commands.UpdateCategory;
using Catalog.Application.Services.Features.CategoryFeature.Queries.GetAllCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody]CreateCategoryCommandRequest createCategoryCommandRequest)
        {
            var result =await _mediator.Send(createCategoryCommandRequest);
            if(result.IsSuccessful)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommandRequest updateCategoryCommandRequest)
        {
            var result = await _mediator.Send(updateCategoryCommandRequest);
            if (result.Response.IsSuccessful)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery]GetAllCategoryQueryRequest getAllCategoryQueryRequest)
        {
            var result = await _mediator.Send(getAllCategoryQueryRequest);
            if (result.Response.IsSuccessful)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
