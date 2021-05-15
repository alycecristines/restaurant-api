using System.Threading.Tasks;
using Restaurant.Application.Interfaces;
using Restaurant.Domain.Interfaces;
using Restaurant.Domain.Entities;
using System.Collections.Generic;
using Restaurant.Domain.QueryFilters;
using System;
using AutoMapper;
using Restaurant.Application.Models.Variation;

namespace Restaurant.Application.Services
{
    public class VariationApplicationService : IVariationApplicationService
    {
        private readonly IVariationDomainService _variationService;
        private readonly IMapper _mapper;

        public VariationApplicationService(IVariationDomainService variationService, IMapper mapper)
        {
            _variationService = variationService;
            _mapper = mapper;
        }

        public async Task<VariationResponseModel> CreateAsync(VariationCreateModel model)
        {
            var newVariation = _mapper.Map<Variation>(model);
            var createdVariation = await _variationService.CreateAsync(newVariation);
            return _mapper.Map<VariationResponseModel>(createdVariation);
        }

        public async Task<VariationResponseModel> UpdateAsync(Guid id, VariationUpdateModel model)
        {
            var newVariation = _mapper.Map<Variation>(model);
            var updatedVariation = await _variationService.UpdateAsync(id, newVariation);
            return _mapper.Map<VariationResponseModel>(updatedVariation);
        }

        public async Task<IEnumerable<VariationResponseModel>> FindAllAsync(VariationQueryFilter filters)
        {
            var variations = await _variationService.FindAllAsync(filters);
            return _mapper.Map<IEnumerable<VariationResponseModel>>(variations);
        }

        public async Task<VariationResponseModel> FindAsync(Guid id)
        {
            var variation = await _variationService.FindAsync(id);
            return _mapper.Map<VariationResponseModel>(variation);
        }
    }
}
