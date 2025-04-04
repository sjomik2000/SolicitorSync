﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Case request template to receive API request for creating a new case.
namespace Cases.Contracts.Requests;
public class CreateCaseRequest
{
        public required string case_name { get; init; }
        public required string client_name { get; init; }
        public required string case_type { get; init; }
        public required string case_state { get; init; }
        public string? assigned_attorney { get; init; }
        public DateTime? court_date { get; init; }
        public required string case_description { get; init; }
        public string? documents { get; init; }
        public string? notes { get; init; }
}

