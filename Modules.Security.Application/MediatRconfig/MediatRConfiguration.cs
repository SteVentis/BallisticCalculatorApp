using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Security.Application.MediatRconfig
{
    public static class MediatRConfiguration
    {
        public static IServiceCollection AddMediatRService(this IServiceCollection services)
        {
            var assembly = typeof(MediatRConfiguration).Assembly;

            services.AddMediatR(config => config.RegisterServicesFromAssembly(assembly));

            return services;
        }
    }
}
