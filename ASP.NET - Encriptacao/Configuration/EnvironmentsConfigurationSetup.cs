using ASP.NET___Encriptacao.Configuration.Environments;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ASP.NET___Encriptacao.Configuration
{
    public static class EnvironmentsConfigurationSetup
    {
        public static void AddEnvironmentVariables(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.Configure<EncryptConfig>(configuration.GetSection(EnvironmentsConstants.EncryptConfigName));
        }    
    }
}