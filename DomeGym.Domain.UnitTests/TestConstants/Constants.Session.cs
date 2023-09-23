namespace DomeGym.Domain.UnitTests.TestConstants;

public static partial class Constants
{
    public static class Session
    {
        public static readonly Guid Id = Guid.NewGuid();
        public static readonly DateOnly Date = DateOnly.FromDateTime(DateTime.UtcNow);
        public static readonly TimeOnly StartTime = TimeOnly.FromDateTime(DateTime.UtcNow);
        public static readonly TimeOnly EndTime = TimeOnly.FromDateTime(DateTime.UtcNow);
    }
}