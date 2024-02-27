using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomeGym.Domain.UnitTests.TestUtils.TestConstants;

namespace DomeGym.Domain.UnitTests.TestUtils.Rooms
{
    public static class RoomFactory
    {
        public static Room CreateRoom(
            int maxSessions = Constants.Room.MaxSessions,
            Guid? id = null)
        {
            return new Room(
                maxSessions: maxSessions,
                id: id ?? Constants.Room.Id);
        }
    }
}