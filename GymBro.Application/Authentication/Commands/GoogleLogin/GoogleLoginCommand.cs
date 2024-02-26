using GymBro.Abstractions;
using GymBro.Application.Authentication.Interfaces;
using GymBro.Application.Authentication.Models;
using GymBro.Application.Common.Interfaces;
using GymBro.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Application.Authentication.Commands.GoogleLogin
{
    public class GoogleLoginCommand:IRequest<Result<JwtResponseVM>>
    {
        [Required]
        public required string IdToken { get; set; }
    }

    public class GoogleLoginCommandHandler : IRequestHandler<GoogleLoginCommand, Result<JwtResponseVM>>
    {

        private readonly IAuthService _authService;

        public GoogleLoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<Result<JwtResponseVM>> Handle(GoogleLoginCommand request, CancellationToken cancellationToken)
        {
            var user=await _authService.GoogleSignIn(request.IdToken);
            if(user is not null)
            {
                var token=_authService.CreateJwtToken(user);
                return Result.Success(new JwtResponseVM { Token=token});
            }
            return Result.Failure<JwtResponseVM>(Error.UnknownError);
        }
    }
}
