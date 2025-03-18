using Cases.Application.Models;
using Cases.Application.Repositories;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cases.Application.Services
{
    public class CaseService : ICaseService
    {
        private readonly ICaseRepository _caseRepository;
        private readonly IValidator<Case> _caseValidator;

        public CaseService(ICaseRepository caseRepository, IValidator<Case> caseValidator)
        {
            _caseRepository = caseRepository;
            _caseValidator = caseValidator;
        }

        public async Task<bool> CreateAsync(Case caseItem)
        {
            await _caseValidator.ValidateAndThrowAsync(caseItem);
            return await _caseRepository.CreateAsync(caseItem);
        }

        public Task<bool> DeleteByIdAsync(Guid id)
        {
            return _caseRepository.DeleteByIdAsync(id);
        }

        public Task<IEnumerable<Case>> GetAllAsync()
        {
            return _caseRepository.GetAllAsync();
        }

        public Task<Case?> GetByIdAsync(Guid id)
        {
            return _caseRepository.GetByIdAsync(id);
        }

        public Task<Case?> GetBySlugAsync(string slug)
        {
            return _caseRepository.GetBySlugAsync(slug);
        }

        public async Task<Case?> UpdateAsync(Case caseItem)
        {
            await _caseValidator.ValidateAndThrowAsync(caseItem);
            var exists = await _caseRepository.ExistsByIdAsync(caseItem.id);
            if (!exists)
            {
                return null;
            }
            await _caseRepository.UpdateAsync(caseItem);
            return caseItem;
        }
    }
}
