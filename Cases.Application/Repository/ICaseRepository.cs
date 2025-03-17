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
        Task<bool> CreateAsync(Case caseItem);

        Task<Case?> GetByIdAsync(Guid id);

        Task<Case?> GetBySlugAsync(string slug);

        Task<IEnumerable<Case>> GetAllAsync();

        Task<bool> UpdateAsync(Case caseItem);

        Task<bool> DeleteByIdAsync(Guid id);

        Task<bool> ExistsByIdAsync(Guid id);
    }
}
