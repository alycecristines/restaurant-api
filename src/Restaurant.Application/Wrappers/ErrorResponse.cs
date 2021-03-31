namespace Restaurant.Application.Wrappers
{
    public class ErrorResponse
    {
        public string Title { get; private set; }
        public object Errors { get; private set; }

        public ErrorResponse(string title, object errors = null)
        {
            Title = title;
            Errors = errors;
        }
    }
}
