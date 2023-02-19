using FreeCourse.Services.PhotoStockAPI.Dtos;
using FreeCourse.Shared.BaseController;
using FreeCourse.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Services.PhotoStockAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : CustomBaseController
    {
        [HttpPost]
        public async Task<IActionResult> PhotoSave(IFormFile photo, CancellationToken cancellationToken)
        {

            if(photo != null && photo.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", photo.FileName);
                using var stream = new FileStream(path, FileMode.Create);

                await photo.CopyToAsync(stream, cancellationToken);
                var reutnPath = $"photos/{photo.FileName}";

                PhotoDto photoDto = new() { Uri = reutnPath };
                return CreateActionResultInstance(ResponseDto<PhotoDto>.Success(photoDto, 200));
            }
            else
            {
                return CreateActionResultInstance(ResponseDto<PhotoDto>.Fail("Photo Is Empty", 400));
            }
          
        }
        [HttpGet]

        public IActionResult PhotoDelete(string photoUrl)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", photoUrl);
            if (!System.IO.File.Exists(path))
            {
                return CreateActionResultInstance(ResponseDto<NoContent>.Fail("Photo Not Found", 404));
            }
            System.IO.File.Delete(path);
            return CreateActionResultInstance(ResponseDto<NoContent>.Success(204));

        }
    }
}
