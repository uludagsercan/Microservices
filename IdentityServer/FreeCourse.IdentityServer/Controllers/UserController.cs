using FreeCourse.IdentityServer.Dtos;
using FreeCourse.IdentityServer.Models;
using FreeCourse.Shared.Dtos;
using IdentityModel;
using IdentityServer4;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel.Client;
using FreeCourse.IdentityServer.Settings;
using Microsoft.Extensions.Options;
using IdentityServer4.Models;

namespace FreeCourse.IdentityServer.Controllers
{
    [Authorize(IdentityServerConstants.LocalApi.PolicyName)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly HttpClient _httpClient;
        private readonly IdentityServerSetting _identityServerSetting;


        public UserController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, HttpClient httpClient, IOptions<IdentityServerSetting> setting)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _httpClient = httpClient;
            _identityServerSetting = setting.Value;
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
            var result = await _userManager.CreateAsync(user, signup.Password);
            var role = await _roleManager.FindByNameAsync("user");
            if (role == null)
            {
                ApplicationRole applicationRole = new()
                {
                    Name = "user"
                };
                var identityResult = await _roleManager.CreateAsync(applicationRole);
                if (identityResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, applicationRole.Name);
                }
            }
            else
            {
              
                    await _userManager.AddToRoleAsync(user, role.Name);
            }

            
            if (!result.Succeeded)
            {
                return BadRequest(ResponseDto<NoContent>.Fail(result.Errors.Select(x => x.Description).ToList(), 400));
            }

            var discoveryEndpoint =await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest()
            {
                Address = _identityServerSetting.ServerUri,
                Policy = new DiscoveryPolicy { RequireHttps = true }

            });
            var passwordTokenRequest = new PasswordTokenRequest
            {
                ClientId ="AngularClientForUser",
                ClientSecret = "secret",
                UserName = signup.Email,
                Password = signup.Password,
                Address = discoveryEndpoint.TokenEndpoint,
            };
            var token = await _httpClient.RequestPasswordTokenAsync(passwordTokenRequest);

            return Ok(token.Json);
        }
        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] SignupDto signup)
        {
            var user = new ApplicationUser
            {
                UserName = signup.Username,
                Email = signup.Email,
                City = signup.City,
            };
            var disco = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = _identityServerSetting.ServerUri,
                Policy = new DiscoveryPolicy { RequireHttps = true }
            });
            var passwordTokenRequest = new PasswordTokenRequest
            {
                ClientId = "AngularClientForUser",
                ClientSecret = "secret",
                UserName = signup.Email,
                Password = signup.Password,
                Address = disco.TokenEndpoint,

            };
            var token = await _httpClient.RequestPasswordTokenAsync(passwordTokenRequest);
            user.RefreshToken = token.RefreshToken;
            var result = await _userManager.UpdateAsync(user);

            return Ok(token.Json);
        }
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);
            if (userIdClaim == null) return BadRequest();
            var user = await _userManager.FindByIdAsync(userIdClaim.Value);
            if (user == null)
                return BadRequest();
            return Ok(new { Id = user.Id, Username = user.UserName, Email = user.Email, City = user.City });
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetPublicToken()
        {
            var disco = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest()
            {
                Address = _identityServerSetting.ServerUri,
                Policy = new DiscoveryPolicy { RequireHttps =true}
            });

            var tokenRequest = new ClientCredentialsTokenRequest();
            tokenRequest.ClientId = "AngularClient";
            tokenRequest.ClientSecret = "secret";
            tokenRequest.GrantType = "client_credentials";
            tokenRequest.Address = disco.TokenEndpoint;
            var token =await _httpClient.RequestTokenAsync(tokenRequest);
            return Ok(token.Json);


        }
    }
}
