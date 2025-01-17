using System.Data;

namespace QBSync.Application.Npgsql.Common.Interfaces;

public interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}