using System.Data.Odbc;
using MediatR;
using QBSync.Application.Common.Extensions;
using QBSync.Application.QB.Common.Interfaces;

namespace QBSync.Application.QB.Features.QBItemCustomColumns.Queries;

public class FetchTableCustomColumnsCommandHandler : IRequestHandler<FetchTableCustomColumnsCommand, List<string>>
{
    private readonly IOdbcConnectionFactory _dbConnectionFactory;

    public FetchTableCustomColumnsCommandHandler(IOdbcConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<List<string>> Handle(FetchTableCustomColumnsCommand request, CancellationToken cancellationToken)
    {
        await using var connection = _dbConnectionFactory.CreateConnection();
        connection.Open();

        var customColumns = new List<string>();
        var query = $"sp_columns {request.TableName}";
        var odbcCommand = new OdbcCommand(query, connection);
        
        await using var reader = await odbcCommand.ExecuteReaderAsync(cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            var columnName = reader.GetStringOrNull("ColumnName");
            
            if (columnName!.StartsWith("CustomField", StringComparison.CurrentCultureIgnoreCase))
            {
                customColumns.Add(columnName);
            }
        }
        
        return customColumns;
    }
}