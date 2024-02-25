using DomeGym.Domain.UnitTests.TestUtils.TestConstants;

namespace DomeGym.Domain.UnitTests.TestUtils.Participants;

public static class ParticipantFactory
{
    public static Participant CreateParticipant(Guid? id = null)
    {
        return new Participant(
            userId: Constants.User.Id,
            id: id ?? Constants.Participant.Id);
    }
}
