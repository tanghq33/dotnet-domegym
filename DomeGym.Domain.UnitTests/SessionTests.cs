using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using DomeGym.Domain.UnitTests.TestUtils.Participants;
using DomeGym.Domain.UnitTests.TestUtils.Sessions;
using Xunit;

namespace DomeGym.Domain.UnitTests;

public class SessionTests
{
    [Fact]
    public void ReserveSpot_WhenNoMoreRoom_ShouldFailReservation()
    {
        var session = SessionFactory.CreateSession(maxParticipants: 1);
        var participant1 = ParticipantFactory.CreateParticipant(id: Guid.NewGuid());
        var participant2 = ParticipantFactory.CreateParticipant(id: Guid.NewGuid());

        session.ReserveSpot(participant1);
        session.ReserveSpot(participant2);

        
    }
}
