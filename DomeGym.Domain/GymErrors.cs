using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorOr;

namespace DomeGym.Domain;
public static class GymErrors
{
    public static readonly Error MaxRoomsReached = Error.Validation(
                code: "Gym.CannotHaveMoreRoomsThanMaxiumumAllowed",
                description: "Cannot have more rooms than the maximum allowed");
}