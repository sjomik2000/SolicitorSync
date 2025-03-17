using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Cases.Application.Repositories;
using Cases.Application.Database;

namespace Cases.Application
{
    public static class ApplicationServiceCollectionExtensions2
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<ICaseRepository, CaseRepository>();
            return services;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton<IDatabaseConnection>(_ => new DatabaseConnection(connectionString));
            services.AddSingleton<DbInitializer>();
            return services;
        }
    }
}
