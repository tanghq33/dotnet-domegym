using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomeGym.Domain.UnitTests.TestUtils.Rooms;
using DomeGym.Domain.UnitTests.TestUtils.Sessions;
using FluentAssertions;
using Xunit;

namespace DomeGym.Domain.UnitTests
{
    public class RoomTests
    {
        [Fact]
        public void AddSession_WhenMoreThanMaximumAllowed_ShouldFail()
        {
            // Arrange
            Room room = RoomFactory.CreateRoom(maxSessions: 2);
            var session1 = SessionFactory.CreateSession(id: Guid.NewGuid());
            var session2 = SessionFactory.CreateSession(id: Guid.NewGuid());
            var session3 = SessionFactory.CreateSession(id: Guid.NewGuid());

            // Act
            var addSessionResult1 = room.AddSession(session1);
            var addSessionResult2 = room.AddSession(session2);
            var addSessionResult3 = room.AddSession(session3);

            // Assert
            addSessionResult1.IsError.Should().BeFalse();
            addSessionResult2.IsError.Should().BeFalse();
            addSessionResult3.IsError.Should().BeTrue();

            addSessionResult3.FirstError.Should().Be(RoomErrors.MaxSessionsReached);
        }
    }
}