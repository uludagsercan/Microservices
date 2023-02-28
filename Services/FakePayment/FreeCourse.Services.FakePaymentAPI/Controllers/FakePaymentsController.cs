using FreeCourse.Shared.BaseController;
using FreeCourse.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Services.FakePaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakePaymentsController : CustomBaseController
    {

        [HttpPost]

        public IActionResult ReceivePayment()
        {
            return CreateActionResultInstance<NoContent>(ResponseDto<NoContent>.Success(200));
        }
    }
}
