using System.Text.Json;

namespace Restaurant.Application.Configurations
{
    public static class JsonConfigurations
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
