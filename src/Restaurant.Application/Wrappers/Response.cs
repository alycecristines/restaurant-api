namespace Restaurant.Application.Wrappers
{
    public class Response
    {
        public object Data { get; private set; }

        public Response(object data)
        {
            Data = data;
        }
    }
}
