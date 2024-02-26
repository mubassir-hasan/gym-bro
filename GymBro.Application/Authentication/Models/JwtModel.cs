using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Application.Authentication.Models
{
    public class JwtModel
    {
        public required string Secret { get; set; }
        public required string ValidIssuer { get; set; }
        public required string ValidAudience { get; set; }
        public required string DurationInMinutes { get; set; }
        public required string RefreshTokenExpiration { get; set; }
    }
}
