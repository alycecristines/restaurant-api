namespace Restaurant.Application.Wrappers
{
    public class ApiResponse
    {
        public object Data { get; private set; }

        public ApiResponse(object data)
        {
            Data = data;
        }
    }
}
