using System.Data.Common;
using QBSync.Application.Common.Extensions;

namespace QBSync.Application.QB.Common.Extensions;

public static class QbDbDataReaderExtensions
{
    public static Dictionary<string, string?> GetCustomFields(this DbDataReader reader, IEnumerable<string> customColumns)
    {
        var result = new Dictionary<string, string?>();
        foreach (var column in customColumns)
        {
            result.Add(column, reader.GetStringOrNull(column));
        }
        
        return result;
    }
}