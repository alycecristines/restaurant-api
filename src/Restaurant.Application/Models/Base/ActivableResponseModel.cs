namespace Restaurant.Application.Models.Base
{
    public abstract class ActivableResponseModel : ResponseModel
    {
        public bool Inactivated { get; set; }
    }
}
