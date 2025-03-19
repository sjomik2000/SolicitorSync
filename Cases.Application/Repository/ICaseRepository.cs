using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cases.Application.Models;

namespace Cases.Application.Repositories
{
    public interface ICaseRepository
    {
        Task<bool> CreateAsync(Case caseItem, CancellationToken token = default);

        Task<Case?> GetByIdAsync(Guid id, CancellationToken token = default);

        Task<Case?> GetBySlugAsync(string slug, CancellationToken token = default);

        Task<IEnumerable<Case>> GetAllAsync(CancellationToken token = default);

        Task<bool> UpdateAsync(Case caseItem, CancellationToken token = default);

        Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default);

        Task<bool> ExistsByIdAsync(Guid id, CancellationToken token = default);
    }
}
