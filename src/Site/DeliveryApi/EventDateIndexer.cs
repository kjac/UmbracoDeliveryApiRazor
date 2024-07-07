using Umbraco.Cms.Core.DeliveryApi;
using Umbraco.Cms.Core.Models;

namespace Site.DeliveryApi;

public class EventDateIndexer : IContentIndexHandler
{
    internal const string FieldName = "eventDate";
    
    public IEnumerable<IndexFieldValue> GetFieldValues(IContent content, string? culture)
    {
        if (content.ContentType.Alias != "event")
        {
            return [];
        }

        var eventDate = content.GetValue<DateTime>("date");
        return eventDate > DateTime.MinValue
            ? new[]
            {
                new IndexFieldValue
                {
                    FieldName = FieldName,
                    Values = [eventDate]
                }
            }
            : [];
    }

    public IEnumerable<IndexField> GetFields()
        => new[]
        {
            new IndexField
            {
                FieldName = FieldName,
                FieldType = FieldType.Date,
                VariesByCulture = false
            }
        };
}