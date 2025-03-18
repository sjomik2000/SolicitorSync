using Cases.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cases.Application.Services
{
    public interface ICaseService
    {
        Task<bool> CreateAsync(Case caseItem);

        Task<Case?> GetByIdAsync(Guid id);

        Task<Case?> GetBySlugAsync(string slug);

        Task<IEnumerable<Case>> GetAllAsync();

        Task<Case?> UpdateAsync(Case caseItem);

        Task<bool> DeleteByIdAsync(Guid id);
    }
}
