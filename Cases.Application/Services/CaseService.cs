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
    //Service layer of application was created to move business logic away from API layer,
    //within this layer Controller actions interact with Repository and Validation.
    public class CaseService : ICaseService
    {
        private readonly ICaseRepository _caseRepository; //Instantiating _caseRepository object
        private readonly IValidator<Case> _caseValidator; //Instantiating _caseValidator object

        //Constructor CashService is used to inject information about caseRepository and caseValidator
        //into _caseRepository and _caseValidator so the objects can be used within this file.
        public CaseService(ICaseRepository caseRepository, IValidator<Case> caseValidator)
        {
            _caseRepository = caseRepository; 
            _caseValidator = caseValidator;
        }
        //All methods are created Asynchronically for API scalability
        // For Create and Update requests, _caseValidator is used to verify correct request format.
        // Then _caseRepository is used to execute the method and make changes to the database.
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
            // Added ExistsById method (within repository layer to prevent database interaction of
            // non existing case
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
