using FreeCourse.IdentityServer.Dtos;
using FreeCourse.IdentityServer.Models;
using FreeCourse.Shared.Dtos;
using IdentityServer4;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;


namespace FreeCourse.IdentityServer.Controllers
{
    [Authorize(IdentityServerConstants.LocalApi.PolicyName)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] SignupDto signup)
        {
            var user = new ApplicationUser
            {
                UserName = signup.Username,
                Email = signup.Email,
                City = signup.City,
            };

            var result = await _userManager.CreateAsync(user,signup.Password);
            if (!result.Succeeded)
            {
                return BadRequest(ResponseDto<NoContent>.Fail(result.Errors.Select(x=> x.Description).ToList(),400));
            }
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var userIdClaim=User.Claims.FirstOrDefault(x=> x.Type == JwtRegisteredClaimNames.Sub);
            if (userIdClaim == null) return BadRequest();
            var user = await _userManager.FindByIdAsync(userIdClaim.Value);
            if(user == null)
                return BadRequest();
            return Ok(new {Id=user.Id,Username=user.UserName,Email=user.Email, City=user.City});
        }
    }
}
