namespace Restaurant.Core.Wrappers
{
    public class ApiSuccessResponse
    {
        public bool Success { get; private set; }
        public object Data { get; private set; }

        public ApiSuccessResponse(object data)
        {
            Success = true;
            Data = data;
        }
    }
}
