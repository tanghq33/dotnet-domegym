using System.Security.Cryptography;
using ErrorOr;

namespace DomeGym.Domain;

public class Session
{
    public Guid Id { get; }
    private readonly Guid _trainerId;
    private readonly List<Guid> _participantsIds = new();
    private readonly int _maxParticipants;
    private readonly DateOnly _date;
    private readonly TimeOnly _startTime;
    private readonly TimeOnly _endTime;

    public Session(DateOnly date, TimeOnly startTime, TimeOnly endTime, int maxParticipants, Guid trainerId, Guid? id = null)
    {
        _date = date;
        _startTime = startTime;
        _endTime = endTime;
        _maxParticipants = maxParticipants;
        _trainerId = trainerId;
        Id = id ?? Guid.NewGuid();
    }

    public ErrorOr<Success> ReserveSpot(Participant participant)
    {
        if (_participantsIds.Count >= _maxParticipants)
        {
            return SessionErrors.ParticipantsLimitReached;
        }
        _participantsIds.Add(participant.Id);

        return Result.Success;
    }

    public ErrorOr<Success> CancelReservation(Participant participant, IDateTimeProvider dateTimeProvider)
    {
        if (IsTooCloseToSession(dateTimeProvider.UtcNow))
        {
            return SessionErrors.CannotCancelReservationTooCloseToSession;
        }

        if (!_participantsIds.Contains(participant.Id))
        {
            return SessionErrors.ReservationNotFound;
        }

        return Result.Success;
    }

    private bool IsTooCloseToSession(DateTime dateTime)
    {
        const int minHours = 24;
        return (_startTime - TimeOnly.FromDateTime(dateTime)).TotalHours < minHours;
    }
}