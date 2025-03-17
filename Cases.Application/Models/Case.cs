using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.CodeDom.Compiler;
using Cases.Application.Tools;

namespace Cases.Application.Models
{
    public partial class Case
    {
        public required Guid id { get; init; }
        public required string case_name { get; init; }
        public required DateTime created_date { get; init; }
        public DateTime? updated_date { get; init; }
        public string slug { get; internal set; } = string.Empty;
        public required string client_name { get; init; }
        public required string case_type { get; set; }
        public required string case_state { get; set; }
        public string? assigned_attorney { get; set; }
        public DateTime? court_date { get; set; }
        public required string case_description { get; set; }
        public string? documents { get; set; }
        public string? notes { get; set; }

        public Case()
        {
            if (!String.IsNullOrEmpty(case_name))
            {
                GenerateSlug();
            }
        }
        public void GenerateSlug()
        {
            if (string.IsNullOrEmpty(slug))
            {
                var sluggedName = SlugRegex().Replace(case_name, string.Empty).ToLower().Replace(" ", "-");
                StringGenerator generator = new StringGenerator();
                var slugId = generator.GenerateString(6);
                slug = $"{sluggedName}-{slugId}";
            }
        }

        public void SetSlug(string newSlug)
        {
            slug = newSlug;
        }

        [GeneratedRegex("[^0-9A-Za-z _-]", RegexOptions.NonBacktracking, 10)]
        private static partial Regex SlugRegex();
    }
}
