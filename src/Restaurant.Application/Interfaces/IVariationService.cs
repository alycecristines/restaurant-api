using Restaurant.Core.Entities;

namespace Restaurant.Application.Interfaces
{
    public interface IVariationService
    {
        Variation Insert(Variation dto);
    }
}
