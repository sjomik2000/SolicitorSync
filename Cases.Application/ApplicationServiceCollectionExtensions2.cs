using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Cases.Application.Repositories;

namespace Cases.Application
{
    public static class ApplicationServiceCollectionExtensions2
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<ICaseRepository, CaseRepository>();
            return services;
        }
    }
}
