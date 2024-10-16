using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicForms.Core.Exceptions
{
    public class RepositoryInteractionException : Exception
    {
        private const string ERROR_MESSAGE = "An error occurred while interacting with the repository";
        public RepositoryInteractionException(): base(ERROR_MESSAGE)
        {
        }

    }
}
