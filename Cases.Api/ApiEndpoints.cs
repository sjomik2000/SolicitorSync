namespace Cases.Api
{
    //This file is used to define and direct HTTP route methods for the API
    public static class ApiEndpoints
    {
        // Common api base string 
        private const string ApiBase = "api";

        public static class Cases
        {
            // Base endpoint for cases
            private const string Base = $"{ApiBase}/cases";
            // API endpoint for creating a new case.
            public const string Create = Base;
            // API endpoint for retrieving a single case by ID or slug using
            // idOrSlug parameter. (see Cases.Controller.cs)
            public const string Get = $"{Base}/{{idOrSlug}}";
            // API endpoint for retrieving all cases.
            public const string GetAll = Base;
            // API endpoint for updating a case by ID.
            public const string Update = $"{Base}/{{id}}";
            // API endpoint for deleting a case by ID.
            public const string Delete = $"{Base}/{{id}}";
        }
    }
}
	
