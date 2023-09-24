using ErrorOr;

namespace DomeGym.Domain;

public class GymErrors
{
    public static readonly Error RoomsLimitReached = Error.Validation(
        code: "Gym.RoomsLimitReached",
        description: "Room limit reached for this gym."
    );
}