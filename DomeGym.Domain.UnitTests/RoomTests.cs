using DomeGym.Domain.UnitTests.TestConstants;
using FluentAssertions;

namespace DomeGym.Domain.UnitTests;

public class RoomTests
{
    [Fact]
    public void CreateSession_WhenMaxSessionsReached_ShouldFail()
    {
        // Arrange
        // Create a room with maximum of 1 session
        // Create a session 1
        // Create a session 2
        var room = new Room(id: Guid.NewGuid(), maxSessions: 1);
        var session1 = new Session(id: Guid.NewGuid(), maxParticipants: 1, startTime: Constants.Session.StartTime, endTime: Constants.Session.EndTime, date: Constants.Session.Date, trainerId: Constants.Trainer.Id);
        var session2 = new Session(id: Guid.NewGuid(), maxParticipants: 1, startTime: Constants.Session.StartTime, endTime: Constants.Session.EndTime, date: Constants.Session.Date, trainerId: Constants.Trainer.Id);

        // Act
        // Add session 1
        // Add session 2
        var addSession1Result = room.AddSession(session1);
        var addSession2Result = room.AddSession(session2);

        // Assert
        // Add session 1 should success
        // Add session 2 should fail
        addSession1Result.IsError.Should().BeFalse();
        addSession2Result.IsError.Should().BeTrue();
        addSession2Result.FirstError.Should().BeEquivalentTo(RoomErrors.SessionsLimitReached);
    }
}