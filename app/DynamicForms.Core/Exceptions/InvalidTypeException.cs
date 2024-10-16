using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms.Core.Exceptions
{
    public class InvalidTypeException : Exception
    {
        private const string ERROR_MESSAGE = "Type provided is invalid.";
        public InvalidTypeException(): base(ERROR_MESSAGE)
        {
        }

    }
}
