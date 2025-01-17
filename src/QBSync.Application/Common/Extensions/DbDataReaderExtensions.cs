using System.Data.Common;

namespace QBSync.Application.Common.Extensions;

public static class DbDataReaderExtensions
{
    public static string? GetStringOrNull(this DbDataReader reader, string columnName)
    {
        return reader.IsDBNull(reader.GetOrdinal(columnName)) ? null : reader.GetString(reader.GetOrdinal(columnName));
    } 
}