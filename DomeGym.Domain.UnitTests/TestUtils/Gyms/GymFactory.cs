
using DomeGym.Domain.UnitTests.TestUtils.TestConstants;

namespace DomeGym.Domain.UnitTests;

public static class GymFactory
{
    public static Gym CreateGym(
        int maxRooms = Constants.Gym.MaxRooms,
        Guid? id = null)
    {
        return new Gym(
            maxRooms: maxRooms, 
            id: id ?? Constants.Gym.Id);
    }
}
