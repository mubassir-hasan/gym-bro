using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Application.Authentication.Models
{
    public record JwtResponseVM
    {
        public required string Token { get; set; }
    }
}
