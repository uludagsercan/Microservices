using Catalog.Application.Services.Features.CategoryFeature.Commands.CreateCategory;
using Catalog.Application.Services.Features.CategoryFeature.Commands.UpdateCategory;
using Catalog.Application.Services.Features.CategoryFeature.Queries.GetAllCategory;
using Catalog.Application.Services.Features.CategoryFeature.Queries.GetAllCategoryWithPage;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Policy ="catalog_write_permission")]
        public async Task<IActionResult> Add([FromBody]CreateCategoryCommandRequest createCategoryCommandRequest)
        {
            var result =await _mediator.Send(createCategoryCommandRequest);
            if(result.Response.IsSuccessful)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut("[action]")]
        [Authorize(Policy = "catalog_write_permission")]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommandRequest updateCategoryCommandRequest)
        {
            var result = await _mediator.Send(updateCategoryCommandRequest);
            if (result.Response.IsSuccessful)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("[action]")]
        [Authorize(Policy = "catalog_read")]
        public async Task<IActionResult> GetAll([FromQuery]GetAllCategoryQueryRequest getAllCategoryQueryRequest)
        {
            var t = HttpContext.Request.Headers["Authorize"];
            var result = await _mediator.Send(getAllCategoryQueryRequest);
            if (result.Response.IsSuccessful)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("[action]/{Page}/{PageSize}")]
        [Authorize(Policy = "catalog_read_permission")]
        public async Task<IActionResult> GetAllCategoryWithPage([FromRoute] GetAllCategoryWtihPageQueryRequest getAllCategoryQueryRequest)
        {
            var result = await _mediator.Send(getAllCategoryQueryRequest);
            if (result.Response.IsSuccessful)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
