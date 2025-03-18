using API.Attributes.Controllers;
using API.DTO.Membership.Actions.LoginUser;
using API.DTO.Membership.Actions.RegisterUser;
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
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserRequest request, CancellationToken ct)
        {
            var unifiedRequest = new AuthenticateUserCommand(request.UserLogin,
                    request.Password)
                .WrapAsUnifiedRequest();

            var result = await unifiedBus.ExecuteAsync<AuthenticateUserCommand, AuthenticateUserDto>(unifiedRequest, ct);
            return OperationResultApiResolver.Resolve(result.OperationDetail, result.Data, null, result.Messages.ToArray());
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserRequest request, CancellationToken ct)
        {
            var unifiedRequest = new RegisterUserCommand(request.UserName,
                    request.Password,
                    request.Email,
                    request.FirstName,
                    request.LastName,
                    request.PhoneNumber)
                .WrapAsUnifiedRequest();

            var result = await unifiedBus.ExecuteAsync<RegisterUserCommand, RegisterUserDto>(unifiedRequest, ct);
            return OperationResultApiResolver.Resolve(result.OperationDetail, result.Data, null, result.Messages.ToArray());
        }
    }
}
