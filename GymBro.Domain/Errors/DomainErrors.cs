using GymBro.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Domain.Errors
{
    public static class DomainErrors
    {
        public static class Title
        {
            public static readonly Error Empty = new ("Title.Empty", "Title is empty");
            public static readonly Error TooLong = new("Title.TooLong", "Title is too long");
        }
    }
}
