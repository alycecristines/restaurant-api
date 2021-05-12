namespace Restaurant.Api.Wrappers
{
    public class ErrorResponse
    {
        public string Title { get; set; }
        public object Errors { get; set; }

        public ErrorResponse(string title, object errors = null)
        {
            Title = title;
            Errors = errors;
        }
    }
}
