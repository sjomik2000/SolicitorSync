namespace Cases.Api
{
    public static class ApiEndpoints
    {
        private const string ApiBase = "api";

        public static class Cases
        {
            private const string Base = $"{ApiBase}/cases";

            public const string Create = Base;

            public const string Get = $"{Base}/{{id}}";

            public const string GetAll = Base;

            public const string Update = $"{Base}/{{id}}";

            public const string Delete = $"{Base}/{{id}}";
        }
    }
}
	
