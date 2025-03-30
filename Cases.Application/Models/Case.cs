using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.CodeDom.Compiler;
using Cases.Application.Tools;

namespace Cases.Application.Models
// Case model structure is registered within this file.
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

        //Once case name is registered, Case constructor is used to call GenerateSlug() method
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
                //Regex is used to strip all unwanted charachters within the case name and replace spaces with - after that
                // GenerateString method is called to concatinate 6 random characters onto the slugID string.
                var sluggedName = SlugRegex().Replace(case_name, string.Empty).ToLower().Replace(" ", "-");
                StringGenerator generator = new StringGenerator();
                var slugId = generator.GenerateString(6);
                slug = $"{sluggedName}-{slugId}";
            }
        }
        // Method to retain the same slug during Update request mapping
        public void SetSlug(string newSlug)
        {
            slug = newSlug;
        }
        //Regex logic for SlugRegex() method.
        [GeneratedRegex("[^0-9A-Za-z _-]", RegexOptions.NonBacktracking, 10)]
        private static partial Regex SlugRegex();
    }
}
