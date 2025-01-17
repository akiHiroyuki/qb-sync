using MediatR;

namespace QBSync.Application.QB.Features.QBItemCustomColumns.Queries;

public record FetchTableCustomColumnsCommand(string TableName) : IRequest<List<string>>;