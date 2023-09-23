namespace DomeGym.Domain;

public class Session
{
    private readonly Guid _id;
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
        _id = id ?? Guid.NewGuid();
    }

    public void ReserveSpot(Participant participant)
    {
        if (_participantsIds.Count >= _maxParticipants)
        {
            throw new Exception("Cannot have more reservations than max participants");
        }
        _participantsIds.Add(participant.Id);
    }

    public void CancelReservation(Participant participant, IDateTimeProvider dateTimeProvider)
    {
        if (IsTooCloseToSession(dateTimeProvider.UtcNow))
        {
            throw new Exception("Unable to cancel reservations.");
        }

        if (!_participantsIds.Contains(participant.Id))
        {
            throw new Exception("Reservation not found.");
        }
    }

    private bool IsTooCloseToSession(DateTime dateTime)
    {
        const int minHours = 24;
        return (_startTime - TimeOnly.FromDateTime(dateTime)).TotalHours < minHours;
    }
}