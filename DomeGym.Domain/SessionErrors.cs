using ErrorOr;

namespace DomeGym.Domain;

public static class SessionErrors
{
    public readonly static Error CannotHaveMoreReservationsThanParticipants = Error.Validation(
        code: "Session.CannotHaveMoreReservationsThanParticipants",
        description: "Cannot have more reservations than participants");

    public readonly static Error CannotCancelReservationTooCloseToSession = Error.Validation(
        code: "Session.CannotCancelReservationTooCloseToSession",
        description: "Cannot cancel reservation too close to session start time");
}