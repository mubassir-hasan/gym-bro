using GymBro.Abstractions;
using GymBro.Application.Authentication.Commands.GoogleLogin;
using GymBro.Application.Authentication.Models;
using GymBro.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace GymBro.Api.Controllers
{
    public class AuthenticationController : ApiControllerBase
    {
        [HttpPost("[action]")]
        public async Task<Result<JwtResponseVM>> GoogleLogin(GoogleLoginCommand request)
        {
            return await Mediator.Send(request);
        }
    }
}
