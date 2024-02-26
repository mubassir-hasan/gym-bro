using GymBro.Application.Authentication.Models;
using GymBro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Application.Authentication.Interfaces
{
    public interface IAuthService
    {
        Task<ApplicationUser?> GoogleSignIn(string idToken);
        string CreateJwtToken(ApplicationUser user);
    }
}
