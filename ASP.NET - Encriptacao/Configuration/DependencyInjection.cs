using System;
using ASP.NET___Encriptacao.Infra.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace ASP.NET___Encriptacao.Configuration
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            Bootstrapper.RegisterServices(services);
        }
    }
}