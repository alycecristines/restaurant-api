using System.Collections.Generic;

namespace Restaurant.Core.Wrappers
{
    public class ApiErrorResponse
    {
        public bool Success { get; private set; }
        public string Title { get; private set; }
        public object Errors { get; private set; }

        public ApiErrorResponse(string title, object errors = null)
        {
            Success = false;
            Title = title;
            Errors = errors;
        }
    }
}
