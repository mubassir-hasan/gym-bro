using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Application.Authentication.Models
{
    public record CreateUserFromSocialLoginModel
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public string? ProfilePicture { get; set; }
        public required string LoginProviderSubject { get; set; }
    }
}
