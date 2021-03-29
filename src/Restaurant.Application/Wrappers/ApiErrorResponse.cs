namespace Restaurant.Application.Wrappers
{
    public class ApiErrorResponse
    {
        public string Title { get; private set; }
        public object Errors { get; private set; }

        public ApiErrorResponse(string title, object errors = null)
        {
            Title = title;
            Errors = errors;
        }
    }
}
