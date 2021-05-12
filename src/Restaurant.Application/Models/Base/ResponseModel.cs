namespace Restaurant.Application.Models.Base
{
    public abstract class ResponseModel
    {
        public string Id { get; set; }
        public bool Inactivated { get; set; }
    }
}
