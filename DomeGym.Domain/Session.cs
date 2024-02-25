namespace DomeGym.Domain;

public class Session
{
    private readonly int _maxParticipants;
    private readonly Guid _id;
    private readonly Guid _trainerId;
    private readonly List<Guid> _participantIds;

    public Session(int maxParticipants, Guid trainerId, Guid? id = null)
    {
        _maxParticipants = maxParticipants;
        _trainerId = trainerId;
        _id = id ?? Guid.NewGuid();
    }
}
