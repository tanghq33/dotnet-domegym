using ErrorOr;

namespace DomeGym.Domain;

public class Gym
{
    private readonly Guid _id;
    private readonly List<Guid> _roomIds = new();
    private readonly int _maxRooms;

    public Gym(Guid id, int maxRooms)
    {
        _id = id;
        _maxRooms = maxRooms;
    }

    public ErrorOr<Success> AddRoom(Room room)
    {
        if (_roomIds.Count >= _maxRooms)
        {
            return GymErrors.RoomsLimitReached;
        }
        
        _roomIds.Add(room.Id);

        return Result.Success;
    }
}