using System.Data.Odbc;
using QBSync.Application.QB.Common.Interfaces;

namespace QBSync.Infrastructure.QB.Common.Persistence;

public class QodbcConnectionFactory : IOdbcConnectionFactory
{
    private readonly string _connectionString;

    public QodbcConnectionFactory(string connectionString)
    {
        _connectionString = connectionString;
    }
    
    public OdbcConnection CreateConnection()
    {
        return new OdbcConnection(_connectionString);
    }
}