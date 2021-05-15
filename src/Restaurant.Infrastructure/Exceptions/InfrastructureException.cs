using System;

namespace Restaurant.Infrastructure.Exceptions
{
    public class InfrastructureException : Exception
    {
        public object Errors { get; set; }

        public InfrastructureException(string message, object errors = null) : base(message)
        {
            Errors = errors;
        }
    }
}
