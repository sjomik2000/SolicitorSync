using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cases.Application.Models
{
    public class Case
    {
        public required int id { get; init; }
        public required string case_name { get; init; }
        public required string client_name { get; init; }
        public required string case_type { get; set; }
        public required string case_state { get; set; }
        public string? assigned_attorney { get; set; }
        public DateTime? court_date { get; set; }
        public required string case_description { get; set; }
        public string? documents { get; set; }
        public string? notes { get; set; }
    }
}
