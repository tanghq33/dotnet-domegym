using ErrorOr;

namespace DomeGym.Domain;

public static class SessionErrors
{
    public readonly static Error SessionIsFull = Error.Validation(
        code: "Session.SessionIsFull",
        description: "Cannot have more participants than the maximum allowed");    

    public readonly static Error CannotCancelReservationTooCloseToSession = Error.Validation(
        code: "Session.CannotCancelReservationTooCloseToSession",
        description: "Cannot cancel reservation too close to the session start time");

    public readonly static Error ParticipantNotFound = Error.NotFound(
        code: "Session.ParticipantNotFound",
        description: "Could not find participant in session");
}
