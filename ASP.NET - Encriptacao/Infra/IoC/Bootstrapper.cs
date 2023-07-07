using ASP.NET___Encriptacao.Application.Interfaces;
using ASP.NET___Encriptacao.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ASP.NET___Encriptacao.Infra.IoC
{
    public static class Bootstrapper
    {
        public static void RegisterServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IEncryptationService, EncryptationService>();
        }
    }
}