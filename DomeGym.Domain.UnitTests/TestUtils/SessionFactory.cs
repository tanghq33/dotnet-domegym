using DomeGym.Domain.UnitTests.TestConstants;

namespace DomeGym.Domain.UnitTests.TestUtils;

public static class SessionFactory
{
    public static Session CreateSession(DateOnly date, TimeOnly startTime, TimeOnly endTime, int maxParticipants, Guid? id = null)
    {
        return new Session(
            date,
            startTime,
            endTime,
            maxParticipants, 
            trainerId: Constants.Trainer.Id, 
            id: id ?? Constants.Session.Id
        );
    }
}