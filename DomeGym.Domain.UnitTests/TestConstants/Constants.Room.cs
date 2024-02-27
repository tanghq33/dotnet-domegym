namespace DomeGym.Domain.UnitTests.TestUtils.TestConstants;
public partial class Constants
{
    public class Room
    {
        public static Guid Id => Guid.NewGuid();
        public const int MaxSessions = 5;
    }
}
