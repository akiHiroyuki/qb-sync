namespace QBSync.Domain.Entities.QBItems;

public class QbItem
{
    public string ListId { get; private set; }
    public string? Name { get; private set; }
    public string? Description { get; private set; }
    public string? Type {get; private set;}
    public IReadOnlyDictionary<string, string?> CustomFields { get; private set; }

    public QbItem(string listId, string? name, string? description, string? type, Dictionary<string, string?> customFields)
    {
        ListId = listId;
        Name = name;
        Description = description;
        Type = type;
        CustomFields = customFields;
    }
}