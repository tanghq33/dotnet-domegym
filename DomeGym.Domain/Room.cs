namespace DomeGym.Domain;

public class Room
{
    public required Guid Id { get; init; }
    public List<Session> Sessions { get; init; } = new();
}