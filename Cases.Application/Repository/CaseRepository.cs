using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cases.Application.Models;

namespace Cases.Application.Repositories
{
    public class CaseRepository : ICaseRepository
    {
        private readonly List<Case> _cases = new();
        public Task<bool> CreateAsync(Case caseItem)
        {
            caseItem.GenerateSlug();
            _cases.Add(caseItem);
            return Task.FromResult(true);
        }

        public Task<bool> DeleteByIdAsync(int id)
        {
            var removedCount = _cases.RemoveAll(x => x.id == id);
            var caseRemoved = removedCount > 0;
            return Task.FromResult(caseRemoved);
        }

        public Task<IEnumerable<Case>> GetAllAsync()
        {
            return Task.FromResult(_cases.AsEnumerable());
        }

        public Task<Case?> GetByIdAsync(int id)
        {
            var caseItem = _cases.SingleOrDefault(x => x.id == id);
            return Task.FromResult(caseItem);
        }

        public Task<Case?> GetBySlugAsync(string slug)
        {
            var caseItem = _cases.SingleOrDefault(x => x.slug == slug);
            return Task.FromResult(caseItem);
        }

        public Task<bool> UpdateAsync(Case caseItem)
        {
            var caseIndex = _cases.FindIndex(x => x.id == caseItem.id);
            if (caseIndex == -1)
            {
                return Task.FromResult(false);
            }

            _cases[caseIndex] = caseItem;
            return Task.FromResult(true);
        }
    }
};
