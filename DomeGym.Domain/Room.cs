namespace DomeGym.Domain;

public class Room
{
    public Guid Id { get; }
    private readonly List<Guid> _sessionIds = new();

    public Room(Guid id)
    {
        Id = id;
    }
}