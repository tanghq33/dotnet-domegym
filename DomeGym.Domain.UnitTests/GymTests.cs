using FluentAssertions;

namespace DomeGym.Domain.UnitTests;

public class GymTests
{
    [Fact]
    public void CreateRoom_WhenMaxRoomsReached_ShouldFail()
    {
        // Arrange
        // Create a gym with a maximum of 1 room
        // Create a room 1
        // Create a room 2
        var gym = new Gym(id: Guid.NewGuid(), maxRooms: 1);
        var room1 = new Room(id: Guid.NewGuid(), maxDailySessions: 1);
        var room2 = new Room(id: Guid.NewGuid(), maxDailySessions: 1);

        // Act
        // Add room 1
        // Add room 2
        var addRoom1Result = gym.AddRoom(room1);
        var addRoom2Result = gym.AddRoom(room2);

        // Assert
        // Add room 1 should success
        // Add room 2 should fail
        addRoom1Result.IsError.Should().BeFalse();
        addRoom2Result.IsError.Should().BeTrue();
        addRoom2Result.FirstError.Should().BeEquivalentTo(GymErrors.RoomsLimitReached);
    }
}