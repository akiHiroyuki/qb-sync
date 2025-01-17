using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using QBSync.Application.Npgsql.Common.Interfaces;
using QBSync.Application.QB.Common.Interfaces;
using QBSync.Infrastructure.Npgsql.Common.Persistence;
using QBSync.Infrastructure.QB.Common.Persistence;

namespace QBSync.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IOdbcConnectionFactory>(
            new QodbcConnectionFactory(configuration.GetConnectionString("QODBCDNSConnectionsString")!));

        services.AddSingleton<IDbConnectionFactory>
            (new NpgsqlConnectionFactory(configuration.GetConnectionString("PostgreSqlConnection")!));
        
        return services;
    }
}