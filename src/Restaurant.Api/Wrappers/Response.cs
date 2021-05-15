namespace Restaurant.Api.Wrappers
{
    public class Response
    {
        public object Data { get; set; }

        public Response(object data = null)
        {
            Data = data;
        }
    }
}
