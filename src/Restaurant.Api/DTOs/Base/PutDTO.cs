namespace Restaurant.Api.DTOs.Base
{
    public abstract class ResponseDTO
    {
        public string Id { get; set; }
        public bool Inactivated { get; set; }
    }
}
