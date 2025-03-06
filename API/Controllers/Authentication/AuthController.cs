using API.DTO.Membership.Actions.LoginUser;
using API.Helpers;
using Domain.DTO.Commands.Specific.Membership;
using Domain.DTO.Common;
using Domain.DTO.Interfaces.UnifiedBus;
using Domain.DTO.Models.Membership;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Authentication
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IUnifiedBus unifiedBus) : ApiBaseController
    {
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserRequest request, CancellationToken ct)
        {
            var loginCommand = new AuthenticateUserCommand(request.UserLogin, request.Password);
            var unifiedRequest = loginCommand.WrapAsUnifiedRequest();

            var result = await unifiedBus.ExecuteAsync<AuthenticateUserCommand, AuthenticateUserDto>(unifiedRequest, ct);

            if (result.IsSuccess)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
