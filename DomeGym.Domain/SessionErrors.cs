using ErrorOr;

namespace DomeGym.Domain;

public static class SessionErrors
{
    public static Error CannotCancelReservationTooCloseToSession = Error.Validation(
        code: "Session.TooCloseToSession",
        description: "Unable to cancel reservations."
    );
    
    public static Error ReservationNotFound = Error.NotFound(
        code: "Session.ReservationNotFound",
        description: "Reservation not found."
    );
    
    public static Error ParticipantsLimitReached = Error.Validation(
        code: "Session.ParticipantsLimitReached",
        description: "Cannot have more reservations than max participants."
    );
}