using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Case response template to be sent to the API response of the all Cases stored within database.
namespace Cases.Contracts.Responses;
public class CasesResponse
    {
        public required IEnumerable<CaseResponse> Items { get; init; } = Enumerable.Empty<CaseResponse>();
    }
