using Catalog.Application.Services.Features.CourseFeature.Commands.CreateCourse;
using Catalog.Application.Services.Features.CourseFeature.Commands.DeleteCourse;
using Catalog.Application.Services.Features.CourseFeature.Commands.UpdateCourse;
using Catalog.Application.Services.Features.CourseFeature.Queries.GetAllCourse;
using Catalog.Application.Services.Features.CourseFeature.Queries.GetAllCourseWithPage;
using Catalog.Application.Services.Features.CourseFeature.Queries.GetCourseById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CoursesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody]CreateCourseCommandRequest request)
        {
            var result =await _mediator.Send(request);
            if (result.Response.IsSuccessful)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> Update([FromBody] UpdateCourseCommandRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.Response.IsSuccessful)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCourseCommandRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.Response.IsSuccessful)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCourseQueryRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.Response.IsSuccessful)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromRoute] GetAllCourseQueryRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.Response.IsSuccessful)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("[action]/{page}/{pageSize}")]
        public async Task<IActionResult> GetAllWithPage([FromRoute] GetAllCourseWithPageQueryRequest request)
        {
            var result = await _mediator.Send(request);
            if (result.Response.IsSuccessful)
                return Ok(result);
            return BadRequest(result);
        }


    }
}
