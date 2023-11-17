using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymBro.Application.Common.Exceptions
{
    public class ApplicationCustomException : Exception
    {
        public ApplicationCustomException() : base() { }
        public ApplicationCustomException(string message)
            : base(message)
        {
        }

        public ApplicationCustomException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
