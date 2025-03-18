using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cases.Contracts.Requests;
public class UpdateCaseRequest
    {
        public string? case_name { get; init; }
        public string? client_name { get; init; }
        public string? case_type { get; init; }
        public string? case_state { get; init; }
        public string? assigned_attorney { get; init; }
        public DateTime? court_date { get; init; }
        public string? case_description { get; init; }
        public string? documents { get; init; }
        public string? notes { get; init; }
    }
