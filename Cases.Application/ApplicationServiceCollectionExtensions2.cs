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
//This file contains custom dependency injections to remove business logic from API layer and store it within Application layer
namespace Cases.Application
{
    public static class ApplicationServiceCollectionExtensions2
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //During AddApplication() execution, Repository, Service and Validation layers are registered within DI container.
            // A singleton implementation ensures that only one instance of a service is created and shared throughout
            // the application's lifetime.
            services.AddSingleton<ICaseRepository, CaseRepository>();
            services.AddSingleton<ICaseService, CaseService>();
            services.AddValidatorsFromAssemblyContaining<CaseValidator>(ServiceLifetime.Singleton);
            return services;
        }

        public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
        {
            //After API is built, AddDatabase() method registers connection layers and initializes Database.
            // Singleton is used to ensure consistent configuration and reduce initialization overhead.
            services.AddSingleton<IDatabaseConnection>(_ => new DatabaseConnection(connectionString));
            services.AddSingleton<DbInitializer>();
            return services;
        }
    }
}
