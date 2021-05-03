using System;

namespace Restaurant.Infrastructure.Exceptions
{
    public class InfrastructureException : Exception
    {
        public object Errors { get; set; }

        public InfrastructureException(string message, object errors) : base(message)
        {
            Errors = errors;
        }

        public InfrastructureException(string message) : base(message)
        {
        }
    }
}
