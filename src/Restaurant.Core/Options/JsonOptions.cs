using System.Text.Json;

namespace Restaurant.Core.Options
{
    public static class JsonOptions
    {
        public static bool IgnoreNullValues => true;
        public static JsonNamingPolicy NamingPolicy => JsonNamingPolicy.CamelCase;

        public static JsonSerializerOptions Create()
        {
            return new JsonSerializerOptions()
            {
                PropertyNamingPolicy = NamingPolicy,
                IgnoreNullValues = IgnoreNullValues
            };
        }
    }
}
