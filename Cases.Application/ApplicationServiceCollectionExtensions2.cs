using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Cases.Application.Repositories;
using Cases.Application.Database;
using Cases.Application.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Cases.Application.Validators;
using Microsoft.Extensions.Logging;

namespace Cases.Application
{
    public static class ApplicationServiceCollectionExtensions2
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<ICaseRepository, CaseRepository>();
            services.AddSingleton<ICaseService, CaseService>();
            services.AddValidatorsFromAssemblyContaining<CaseValidator>(ServiceLifetime.Singleton);
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
