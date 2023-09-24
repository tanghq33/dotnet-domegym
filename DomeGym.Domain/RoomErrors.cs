using ErrorOr;

namespace DomeGym.Domain;

public static class RoomErrors
{
    public static readonly Error SessionsLimitReached = Error.Validation(
        code: "Room.SessionsLimitReached",
        description: "Sessions limit reached for this room."
    );
}