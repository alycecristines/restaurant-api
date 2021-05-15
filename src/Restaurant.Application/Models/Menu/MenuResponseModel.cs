using Restaurant.Application.Models.Base;
using Restaurant.Domain.Enumerators;

namespace Restaurant.Application.Models.Menu
{
    public class MenuResponseModel : ActivableResponseModel
    {
        public string Description { get; set; }
        public DaysOfWeek Availability { get; set; }
    }
}
