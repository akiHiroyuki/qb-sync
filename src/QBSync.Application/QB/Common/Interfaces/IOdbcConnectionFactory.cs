using System.Data.Odbc;

namespace QBSync.Application.QB.Common.Interfaces;

public interface IOdbcConnectionFactory
{
    OdbcConnection CreateConnection();
}