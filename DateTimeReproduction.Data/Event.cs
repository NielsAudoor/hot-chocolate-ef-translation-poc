namespace DateTimeReproduction.Data;

public class Event
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public DateTimeOffset Timestamp { get; set; }
}
