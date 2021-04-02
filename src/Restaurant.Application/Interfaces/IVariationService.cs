using System;
using System.Collections.Generic;
using Restaurant.Application.QueryParams;
using Restaurant.Core.Entities;

namespace Restaurant.Application.Interfaces
{
    public interface IVariationService
    {
        Variation Insert(Variation newVariation);
        IEnumerable<Variation> GetAll(VariationQueryParams queryParams);
        Variation Get(Guid id);
        Variation Update(Guid id, Variation newVariation);
        void Delete(Guid id);
    }
}
