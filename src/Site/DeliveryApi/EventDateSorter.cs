using Umbraco.Cms.Core;
using Umbraco.Cms.Core.DeliveryApi;

namespace Site.DeliveryApi;

public class EventDateSorter : ISortHandler
{
    private const string SortPrefix = "eventDate:";
    
    public bool CanHandle(string query)
        => query.StartsWith(SortPrefix);

    public SortOption BuildSortOption(string sort)
        => new()
        {
            FieldName = EventDateIndexer.FieldName,
            Direction = sort.Substring(SortPrefix.Length) == "asc"
                ? Direction.Ascending
                : Direction.Descending
        };
}