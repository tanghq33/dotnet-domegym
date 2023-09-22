namespace DomeGym.Domain;

public class Session
{
    public required Guid Id { get; init; }
    public required Trainer Trainer { get; set; }
    public List<Participants> Participants { get; init; } = new();
}