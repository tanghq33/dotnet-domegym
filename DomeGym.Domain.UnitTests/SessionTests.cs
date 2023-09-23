using DomeGym.Domain.UnitTests.TestConstants;
using DomeGym.Domain.UnitTests.TestUtils;
using FluentAssertions;
using NSubstitute;

namespace DomeGym.Domain.UnitTests;

public class SessionTests
{
    private readonly IDateTimeProvider _dateTimeProvider = Substitute.For<IDateTimeProvider>();
    
    [Fact]
    public void ReserveSpot_WhenNoMoreRoom_ShouldFailReservation()
    {
        // Arrange
        // Create a session with a maximum of 1 participants
        // Create 2 participants
        var session = SessionFactory.CreateSession(
            date: Constants.Session.Date, 
            startTime: Constants.Session.StartTime, 
            endTime: Constants.Session.EndTime, 
            maxParticipants: 1
        );
        
        var participant1 = ParticipantFactory.CreateParticipant(id: Guid.NewGuid(), userId: Guid.NewGuid());
        var participant2 = ParticipantFactory.CreateParticipant(id: Guid.NewGuid(), userId: Guid.NewGuid());

        // Act
        // Add participant 1
        // Add participant 2
        session.ReserveSpot(participant1);
        var action = () => session.ReserveSpot(participant2);

        // Assert
        // Participant 2 reservation should fail
        action.Should().ThrowExactly<Exception>();
    }

    [Fact]
    public void CancelReservation_WhenCancellationIsTooCloseToSession_ShouldFailCancellation()
    {
        // Arrange
        // Create a session
        // Create a participant
        // Reserve a spot
        var session = SessionFactory.CreateSession(
            date: Constants.Session.Date, 
            startTime: Constants.Session.StartTime, 
            endTime: Constants.Session.EndTime, 
            maxParticipants: 1
        );
        
        var participant = ParticipantFactory.CreateParticipant(id: Guid.NewGuid(), userId: Guid.NewGuid());
        
        session.ReserveSpot(participant);

        _dateTimeProvider.UtcNow.Returns(Constants.Session.Date.ToDateTime(TimeOnly.MinValue));
        
        // Act
        // Cancel the reservation less than 24 hours before the session
        var action = () => session.CancelReservation(participant, _dateTimeProvider);
        
        // Assert
        // The cancellation should fail
        action.Should().ThrowExactly<Exception>();

    }
}