using System.Data.Odbc;
using MediatR;
using QBSync.Application.Common.Extensions;
using QBSync.Application.QB.Common;
using QBSync.Application.QB.Common.Extensions;
using QBSync.Application.QB.Common.Interfaces;
using QBSync.Application.QB.Features.QBItemCustomColumns.Queries;
using QBSync.Domain.Entities.QBItems;

namespace QBSync.Application.QB.Features.QBItems.Queries;

public class FetchQbItemsCommandHandler : IRequestHandler<FetchQbItemsCommand, List<QbItem>>
{
    private readonly IOdbcConnectionFactory _dbConnectionFactory;
    private IMediator _mediator;
    
    public FetchQbItemsCommandHandler(IOdbcConnectionFactory dbConnectionFactory, IMediator mediator)
    {
        _dbConnectionFactory = dbConnectionFactory;
        _mediator = mediator;
    }
    
    public async Task<List<QbItem>> Handle(FetchQbItemsCommand request, CancellationToken cancellationToken)
    {
        var customColumns = await _mediator.Send(new FetchTableCustomColumnsCommand(Constants.Tables.Items), cancellationToken);
        var items = new List<QbItem>();
        
        await using var connection = _dbConnectionFactory.CreateConnection();
        connection.Open();
        
        var query = BuildQuery(customColumns);
        var command = new OdbcCommand(query, connection);
        
        await using var reader = await command.ExecuteReaderAsync(cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            items.Add(new QbItem(
                    listId: reader["ListID"].ToString()!,
                    name: reader.GetStringOrNull("Name"),
                    description: reader.GetStringOrNull("Name"),
                    type:reader.GetStringOrNull("Name"),
                    customFields: reader.GetCustomFields(customColumns)
                ));
        }
        
        return items;
    }

    private string BuildQuery(IEnumerable<string> customColumns)
    {
        return $"SELECT ListID,Name,Description,{string.Join(',', customColumns)} FROM {Constants.Tables.Items}";
    }
}