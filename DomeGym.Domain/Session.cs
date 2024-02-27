using DomeGym.Domain.Common;
using ErrorOr;

namespace DomeGym.Domain;

public class Session : Entity
{
    private readonly int _maxParticipants;
    private readonly Guid _id;
    private readonly Guid _trainerId;
    private readonly List<Guid> _participantIds = new();
    private readonly DateOnly _date;
    private readonly TimeOnly _startTime;
    private readonly TimeOnly _endTime;

    public Session(
        DateOnly date, 
        TimeOnly startTime, 
        TimeOnly endTime,
        int maxParticipants, 
        Guid trainerId, 
        Guid? id = null) : base(id ?? Guid.NewGuid())
    {
        _date = date;
        _startTime = startTime;
        _endTime = endTime;
        _maxParticipants = maxParticipants;
        _trainerId = trainerId;
    }

    public ErrorOr<Success> ReserveSpot(Participant participant)
    {
        if (_participantIds.Count >= _maxParticipants)
        {
            return SessionErrors.SessionIsFull;
        }

        _participantIds.Add(participant.Id);

        return Result.Success;
    }

    public ErrorOr<Success> CancelReservation(Participant participant, IDateTimeProvider dateTimeProvider)
    {
        if(IsTooCloseToSession(dateTimeProvider.UtcNow))
        {
            return SessionErrors.CannotCancelReservationTooCloseToSession;
        }

        if(!_participantIds.Remove(participant.Id))
        {
            return SessionErrors.ParticipantNotFound;
        }

        return Result.Success;
    }

    private bool IsTooCloseToSession(DateTime utcNow)
    {
        const int MinHours = 24;
        return (_date.ToDateTime(_startTime) - utcNow).TotalHours < MinHours;
    }
}
