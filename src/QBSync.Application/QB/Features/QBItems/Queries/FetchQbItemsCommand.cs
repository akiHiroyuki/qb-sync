using MediatR;
using QBSync.Domain.Entities.QBItems;

namespace QBSync.Application.QB.Features.QBItems.Queries;

public record FetchQbItemsCommand : IRequest<List<QbItem>>;