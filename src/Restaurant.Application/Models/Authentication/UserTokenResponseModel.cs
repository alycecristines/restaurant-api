namespace Restaurant.Application.Models
{
    public class UserTokenResponseModel
    {
        public UserResponseModel User { get; set; }
        public string Token { get; set; }
    }
}
