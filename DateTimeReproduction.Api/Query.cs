using DateTimeReproduction.Data;
using HotChocolate.Data.Sorting;

namespace DateTimeReproduction.Api;

public class Query
{
    [UseSorting<EventSortType>]
    public IExecutable<OutputTypes.Event> GetEvents(AppDbContext context)
    {
        var results = context.Events
            .Select(x => new OutputTypes.Event
            {
                Timestamp = x.Timestamp.DateTime
            });

        return results.AsExecutable();
    }
}


public class EventSortType : SortInputType<OutputTypes.Event>
{
    protected override void Configure(ISortInputTypeDescriptor<OutputTypes.Event> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(f => f.Timestamp);
    }
}

