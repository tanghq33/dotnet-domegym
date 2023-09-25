using DomeGym.Domain.UnitTests.TestConstants;
using FluentAssertions;

namespace DomeGym.Domain.UnitTests;

public class RoomTests
{
    [Fact]
    public void ScheduleSession_WhenMoreThanSubscriptionAllows_ShouldFail()
    {
        // Arrange
        // Create a room with maximum of 1 session
        // Create a session 1
        // Create a session 2
        var room = new Room(id: Guid.NewGuid(), maxDailySessions: 1);
        var session1 = new Session(id: Guid.NewGuid(), maxParticipants: 1, startTime: Constants.Session.StartTime, endTime: Constants.Session.EndTime, date: Constants.Session.Date, trainerId: Constants.Trainer.Id);
        var session2 = new Session(id: Guid.NewGuid(), maxParticipants: 1, startTime: Constants.Session.StartTime, endTime: Constants.Session.EndTime, date: Constants.Session.Date, trainerId: Constants.Trainer.Id);

        // Act
        // Add session 1
        // Add session 2
        var addSession1Result = room.ScheduleSession(session1);
        var addSession2Result = room.ScheduleSession(session2);

        // Assert
        // Add session 1 should success
        // Add session 2 should fail
        addSession1Result.IsError.Should().BeFalse();
        addSession2Result.IsError.Should().BeTrue();
        addSession2Result.FirstError.Should().BeEquivalentTo(RoomErrors.CannotHaveMoreSessionThanSubscriptionAllows);
    }

    [Fact]
    public void CreateSession_WhenOverlappingSessionExists_ShouldFail()
    {
        // Arrange
        // Create a room with maximum of 5 session
        // Create a session 1 with same date and time
        // Create a session 2 with same date and time
        var room = new Room(id: Guid.NewGuid(), maxDailySessions: 5);
        var session1 = new Session(id: Guid.NewGuid(), maxParticipants: 1, startTime: Constants.Session.StartTime, endTime: Constants.Session.EndTime, date: Constants.Session.Date, trainerId: Constants.Trainer.Id);
        var session2 = new Session(id: Guid.NewGuid(), maxParticipants: 1, startTime: Constants.Session.StartTime, endTime: Constants.Session.EndTime, date: Constants.Session.Date, trainerId: Constants.Trainer.Id);
        
        // Act
        // Add session 1
        // Add session 2
        var addSession1Result = room.ScheduleSession(session1);
        var addSession2Result = room.ScheduleSession(session2);
        
        // Assert
        // Add session 1 should success
        // Add session 2 should fail
        addSession1Result.IsError.Should().BeFalse();
        addSession2Result.IsError.Should().BeTrue();
        addSession2Result.FirstError.Should().BeEquivalentTo(RoomErrors.SessionsOverlapped);
    }
}