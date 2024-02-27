using DomeGym.Domain.Common;
using ErrorOr;

namespace DomeGym.Domain;

public class Room : Entity
{
    private readonly Guid _id;
    private readonly List<Guid> _sessionIds = new();
    private readonly int _maxSessions;

    public Room(int maxSessions, Guid? id = null)
        : base(id ?? Guid.NewGuid())
    {
        _maxSessions = maxSessions;
    }

    public ErrorOr<Success> AddSession(Session session)
    {
        if (_sessionIds.Count >= _maxSessions)
        {
            return Error.Validation(
                code: "Room.MaxSessionsReached",
                description: "The maximum number of sessions has been reached."
            );
        }

        _sessionIds.Add(session.Id);
        
        return Result.Success;
    }
}
