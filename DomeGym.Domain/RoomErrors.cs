using ErrorOr;

namespace DomeGym.Domain;

public static class RoomErrors
{
    public static readonly Error CannotHaveMoreSessionThanSubscriptionAllows = Error.Validation(
        code: "Room.CannotHaveMoreSessionThanSubscriptionAllows",
        description: "A room cannot have more scheduled sessions than the subscription allows"
    );
    
    public static readonly Error SessionsOverlapped = Error.Validation(
        code: "Room.SessionsOverlapped",
        description: "A room cannot have 2 or more overlapping sessions."
    );
    
    public static readonly Error SessionsExists = Error.Validation(
        code: "Room.SessionsExists",
        description: "The specified sessions already exists in room."
    );
}