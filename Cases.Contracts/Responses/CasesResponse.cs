using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cases.Contracts.Responses
{
    class CasesResponse
    {
        public required IEnumerable<CaseResponse> Items { get; init; } = Enumerable.Empty<CaseResponse>();
    }
}
