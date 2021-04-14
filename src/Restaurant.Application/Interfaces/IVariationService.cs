using System;
using System.Collections.Generic;
using Restaurant.Core.QueryObjects;
using Restaurant.Core.Entities;

namespace Restaurant.Application.Interfaces
{
    public interface IVariationService
    {
        Variation Insert(Variation newVariation);
        IEnumerable<Variation> GetAll(VariationQuery queryParams);
        Variation Get(Guid id);
        Variation Update(Guid id, Variation newVariation);
        void Delete(Guid id);
    }
}
