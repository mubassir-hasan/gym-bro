using GymBro.Application.Authentication.Enums;
using GymBro.Application.Authentication.Interfaces;
using GymBro.Application.Authentication.Models;
using GymBro.Application.Common.Interfaces;
using GymBro.Application.Common.Models;
using GymBro.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Extensions;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Google.Apis.Auth.GoogleJsonWebSignature;

namespace GymBro.Api.Services
{
    public class AuthService : IAuthService
    {
        private readonly JwtModel _jwt;
        private readonly GoogleAuthConfigModel _googleConfig;
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<AuthService> _logger;

        public AuthService(IOptions<JwtModel> jwt, IOptions<GoogleAuthConfigModel> googleConfig, IApplicationDbContext applicationDbContext, UserManager<ApplicationUser> userManager, ILogger<AuthService> logger)
        {
            _jwt = jwt.Value;
            _googleConfig = googleConfig.Value;
            _applicationDbContext = applicationDbContext;
            _userManager = userManager;
            _logger = logger;

        }

        /// <summary>
        /// Creates JWT Token
        /// </summary>
        /// <param name="user">the user</param>
        /// <returns>System.String</returns>
        public string CreateJwtToken(ApplicationUser user)
        {

            var key = Encoding.ASCII.GetBytes(_jwt.Secret);

            var userClaims = BuildUserClaims(user);

            var signKey = new SymmetricSecurityKey(key);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.ValidIssuer,
                notBefore: DateTime.UtcNow,
                audience: _jwt.ValidAudience,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(_jwt.DurationInMinutes)),
                claims: userClaims,
                signingCredentials: new SigningCredentials(signKey, SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        public async Task<ApplicationUser?> GoogleSignIn(string idToken)
        {
            Payload payload = new Payload();
            try
            {
                payload = await ValidateAsync(idToken, new ValidationSettings
                {
                    Audience = new[] { _googleConfig.ClientId }
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);

            }
            var userToBeCreated = new CreateUserFromSocialLoginModel
            {
                Email = payload.Email,
                FirstName=payload.GivenName,
                LastName=payload.FamilyName,
                ProfilePicture=payload.Picture,
                LoginProviderSubject=payload.Subject
            };
            var user =await CreateUserFromSocialLogin(userToBeCreated, LoginProvider.Google);
            return user;
        }
        /// <summary>
        /// Builds the UserClaims
        /// </summary>
        /// <param name="user">the User</param>
        /// <returns>List&lt;System.Security.Claims&gt;</returns>
        private List<Claim> BuildUserClaims(ApplicationUser user)
        {
            var userClaims = new List<Claim>()
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),

                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            if (!string.IsNullOrEmpty(user.Email))
            {
                userClaims.Add(new Claim(ClaimTypes.Email, user.Email));
            }

            return userClaims;
        }

        private async Task<ApplicationUser?> CreateUserFromSocialLogin(CreateUserFromSocialLoginModel socialModel, LoginProvider loginProvider)
        {
            //CHECKS IF THE USER HAS NOT ALREADY BEEN LINKED TO AN IDENTITY PROVIDER
            var user = await _userManager.FindByLoginAsync(loginProvider.GetDisplayName(), socialModel.LoginProviderSubject);
            if (user is not null)
            {
                return user;
            }
            user = await _userManager.FindByEmailAsync(socialModel.Email);

            if (user is null)
            {
                user = new ApplicationUser
                {
                    FirstName = socialModel.FirstName,
                    LastName = socialModel.LastName,
                    Email = socialModel.Email,
                    UserName = socialModel.Email,
                    ProfilePicture = socialModel.ProfilePicture,
                    EmailConfirmed = true
                };
                await _userManager.CreateAsync(user);
            }
            UserLoginInfo loginInfo = new UserLoginInfo(loginProvider.GetDisplayName(), socialModel.LoginProviderSubject, loginProvider.GetDisplayName());
            var result = await _userManager.AddLoginAsync(user, loginInfo);
            if (result.Succeeded)
            {
                return user;
            }
            return null;
        }
    }
}
