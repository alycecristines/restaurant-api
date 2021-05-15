using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Restaurant.Api.Options
{
    public static class JsonOptions
    {
        public static IContractResolver ContractResolver => new CamelCasePropertyNamesContractResolver();
        public static NullValueHandling NullValueHandling => NullValueHandling.Ignore;
        public static ReferenceLoopHandling ReferenceLoopHandling => ReferenceLoopHandling.Ignore;

        public static JsonSerializerSettings Create()
        {
            return new JsonSerializerSettings()
            {
                ContractResolver = ContractResolver,
                NullValueHandling = NullValueHandling,
                ReferenceLoopHandling = ReferenceLoopHandling
            };
        }
    }
}
