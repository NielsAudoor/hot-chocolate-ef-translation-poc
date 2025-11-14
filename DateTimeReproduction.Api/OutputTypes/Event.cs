namespace DateTimeReproduction.Api.OutputTypes;

public sealed record Event
{
    public DateTime Timestamp { get; set; }
}