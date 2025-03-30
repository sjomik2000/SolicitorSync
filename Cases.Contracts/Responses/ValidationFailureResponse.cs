using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
// Validation failure response template to be sent to the API response when the request fails to contain required validation.
namespace Cases.Contracts.Responses
{
    public class ValidationFailureResponse
    {
        public required IEnumerable<ValidationResponse> Errors { get; init; }
    }

    public class ValidationResponse
    {
        public required string property_name { get; init; }
        public required string message { get; init; }
    }
}
