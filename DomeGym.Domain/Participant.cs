namespace DomeGym.Domain;

public class Participant
{
    public Guid Id { get; }
    private readonly Guid _userId;
    private readonly List<Guid> _sessionIds = new();

    public Participant(Guid userId, Guid? id = null)
    {
        Id = id ?? Guid.NewGuid();
        _userId = userId;
    }
}