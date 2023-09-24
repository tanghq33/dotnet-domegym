using ErrorOr;

namespace DomeGym.Domain;

public class Room
{
    public Guid Id { get; }
    private readonly List<Guid> _sessionIds = new();
    private readonly int _maxSessions;

    public Room(Guid id, int maxSessions)
    {
        Id = id;
        _maxSessions = maxSessions;
    }

    public ErrorOr<Success> AddSession(Session session)
    {
        if (_sessionIds.Count >= _maxSessions)
        {
            return RoomErrors.SessionsLimitReached;
        }
        
        _sessionIds.Add(session.Id);

        return Result.Success;
    }
}