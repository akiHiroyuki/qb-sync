using System.Data;
using Npgsql;
using QBSync.Application.Npgsql.Common.Interfaces;

namespace QBSync.Infrastructure.Npgsql.Common.Persistence;

public class NpgsqlConnectionFactory : IDbConnectionFactory
{
    private readonly string _connectionString;

    public NpgsqlConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection CreateConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}