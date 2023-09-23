using ErrorOr;

namespace DomeGym.Domain;

public static class SessionErrors
{
    public static readonly Error CannotCancelReservationTooCloseToSession = Error.Validation(
        code: "Session.TooCloseToSession",
        description: "Unable to cancel reservations."
    );
    
    public static readonly Error ReservationNotFound = Error.NotFound(
        code: "Session.ReservationNotFound",
        description: "Reservation not found."
    );
    
    public static readonly Error ParticipantsLimitReached = Error.Validation(
        code: "Session.ParticipantsLimitReached",
        description: "Cannot have more reservations than max participants."
    );
}