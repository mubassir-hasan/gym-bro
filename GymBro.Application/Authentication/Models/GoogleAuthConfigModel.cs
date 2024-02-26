﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Application.Authentication.Models
{
    public record GoogleAuthConfigModel
    {
        public required string ClientId { get; set; }
        public required string ClientSecret { get; set; }
    }
}
