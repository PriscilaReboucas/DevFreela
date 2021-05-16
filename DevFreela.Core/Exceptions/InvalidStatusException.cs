using System;

namespace DevFreela.Core.Exceptions
{
    public class InvalidStatusException : Exception
    {
        public InvalidStatusException(string entity) : base($"{entity} has an invalid status.")
        {

        }
    }
}
