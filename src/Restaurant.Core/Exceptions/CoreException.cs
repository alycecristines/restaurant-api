using System;

namespace Restaurant.Core.Exceptions
{
    public class CoreException : Exception
    {
        public CoreException(string message) : base(message)
        {
        }
    }
}
