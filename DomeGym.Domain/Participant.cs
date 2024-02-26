namespace DomeGym.Domain;

public class Participant
{
    public Guid Id { get; }
    private readonly Guid _userId;

    private readonly List<Guid> _sessionIds;

    public Participant(Guid userId, Guid? id = null)
    {
        _userId = userId;
        Id = id ?? Guid.NewGuid();
    }
}
