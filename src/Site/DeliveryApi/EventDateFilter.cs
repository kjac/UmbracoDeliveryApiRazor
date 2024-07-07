using System.Text.RegularExpressions;
using Umbraco.Cms.Core.DeliveryApi;

namespace Site.DeliveryApi;

public partial class EventDateFilter : IFilterHandler
{
    public bool CanHandle(string query)
        => FilterParserRegex().IsMatch(query);

    public FilterOption BuildFilterOption(string filter)
    {
        var match = FilterParserRegex().Match(filter);
        if (match.Success is false)
        {
            throw new ArgumentException(null, nameof(filter));
        }

        var filterOperation = match.Groups["operator"].Value switch
        {
            ":" => FilterOperation.Is,
            ">" => FilterOperation.GreaterThan,
            ">:" => FilterOperation.GreaterThanOrEqual,
            "<" => FilterOperation.LessThan,
            "<:" => FilterOperation.LessThanOrEqual,
            _ => FilterOperation.Is
        };

        var filterValue = match.Groups["value"].Value;
        return new FilterOption
        {
            FieldName = EventDateIndexer.FieldName,
            Operator = filterOperation,
            Values = [filterValue]
        };
    }

    [GeneratedRegex("eventDate(?<operator>[><:!]*)(?<value>.*)", RegexOptions.IgnoreCase)]
    private static partial Regex FilterParserRegex();
}