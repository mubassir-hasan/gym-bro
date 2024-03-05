using GymBro.Application.Common.Interfaces;
using System.Security.Claims;

namespace GymBro.Api.Services
{
    public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
    {
        public string? UserId => httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        public string? FullName => httpContextAccessor.HttpContext?.User?.FindFirstValue("FullName");
        public string? UserName => httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);
    }
}
