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

        public async Task<bool> CreateAsync(Case caseItem, CancellationToken token = default)
        {
            await _caseValidator.ValidateAndThrowAsync(caseItem, cancellationToken: token);
            return await _caseRepository.CreateAsync(caseItem, token);
        }

        public Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default)
        {
            return _caseRepository.DeleteByIdAsync(id, token);
        }

        public Task<IEnumerable<Case>> GetAllAsync(CancellationToken token = default)
        {
            return _caseRepository.GetAllAsync(token);
        }

        public Task<Case?> GetByIdAsync(Guid id, CancellationToken token = default)
        {
            return _caseRepository.GetByIdAsync(id, token);
        }

        public Task<Case?> GetBySlugAsync(string slug, CancellationToken token = default)
        {
            return _caseRepository.GetBySlugAsync(slug, token);
        }

        public async Task<Case?> UpdateAsync(Case caseItem, CancellationToken token = default)
        {
            await _caseValidator.ValidateAndThrowAsync(caseItem, cancellationToken: token);
            var exists = await _caseRepository.ExistsByIdAsync(caseItem.id, token);
            if (!exists)
            {
                return null;
            }
            await _caseRepository.UpdateAsync(caseItem, token);
            return caseItem;
        }
    }
}
