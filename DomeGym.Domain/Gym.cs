using DomeGym.Domain.Common;
using ErrorOr;

namespace DomeGym.Domain;

public class Gym : Entity
{
    private readonly List<Guid> _roomIds = new();
    private Guid id;
    private int _maxRooms;

    public Gym(int maxRooms, Guid? id = null)
        : base(id ?? Guid.NewGuid())
    {
        _maxRooms = maxRooms;
    }

    public ErrorOr<Success> AddRoom(Room room)
    {
        if (_roomIds.Count >= _maxRooms)
        {
            return Error.Validation(
                code: "Gym.CannotHaveMoreRoomsThanMaxiumumAllowed",
                description: "Cannot have more rooms than the maximum allowed");
        }

        _roomIds.Add(room.Id);
        
        return Result.Success;
    }
}
