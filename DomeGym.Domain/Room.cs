using ErrorOr;

namespace DomeGym.Domain;

public class Room
{
    public Guid Id { get; }
    private readonly List<Guid> _sessionIds = new();
    private readonly int _maxDailySessions;

    public Room(Guid id, int maxDailySessions)
    {
        Id = id;
        _maxDailySessions = maxDailySessions;
    }

    public ErrorOr<Success> ScheduleSession(Session session)
    {
        if (_sessionIds.Any(id => id.Equals(session.Id)))
        {
            return RoomErrors.SessionsExists;
        }
        
        if (_sessionIds.Count >= _maxDailySessions)
        {
            return RoomErrors.CannotHaveMoreSessionThanSubscriptionAllows;
        }
        
        _sessionIds.Add(session.Id);

        return Result.Success;
    }
}