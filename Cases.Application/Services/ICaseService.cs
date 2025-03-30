using Cases.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cases.Application.Services
{
    //Interface for Service layer to define all service layer actions.
    public interface ICaseService
    {
        Task<bool> CreateAsync(Case caseItem, CancellationToken token = default);

        Task<Case?> GetByIdAsync(Guid id, CancellationToken token = default);

        Task<Case?> GetBySlugAsync(string slug, CancellationToken token = default);

        Task<IEnumerable<Case>> GetAllAsync(CancellationToken token = default);

        Task<Case?> UpdateAsync(Case caseItem, CancellationToken token = default);

        Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default);
    }
}
