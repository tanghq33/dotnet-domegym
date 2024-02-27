using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;

namespace DomeGym.Domain
{
    public static class RoomErrors
    {
        public readonly static Error MaxSessionsReached = Error.Validation(
            code: "Room.MaxSessionsReached",
            description: "The maximum number of sessions has been reached."
        );
    }
}