using DomeGym.Domain.UnitTests.TestUtils.Rooms;
using FluentAssertions;
using Xunit;

namespace DomeGym.Domain.UnitTests;

public class GymTests
{
    [Fact]
    public void AddRoom_WhenMoreThanSubscriptionAllows_ShouldFail()
    {
        // Arrange
        Gym gym = GymFactory.CreateGym(maxRooms: 2);
        Room room1 = RoomFactory.CreateRoom(id: Guid.NewGuid());
        Room room2 = RoomFactory.CreateRoom(id: Guid.NewGuid());
        Room room3 = RoomFactory.CreateRoom(id: Guid.NewGuid());

        // Act
        var addRoomResult1 = gym.AddRoom(room1);
        var addRoomResult2 = gym.AddRoom(room2);
        var addRoomResult3 = gym.AddRoom(room3);

        // Assert
        addRoomResult1.IsError.Should().BeFalse();
        addRoomResult2.IsError.Should().BeFalse();
        addRoomResult3.IsError.Should().BeTrue();

        addRoomResult3.FirstError.Should().Be(GymErrors.MaxRoomsReached);
    }
}
