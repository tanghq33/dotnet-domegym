using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomeGym.Domain.UnitTests.TestUtils.TestConstants;
public partial class Constants
{
    public class Session
    {
        public static Guid Id => Guid.NewGuid();
        public static DateOnly Date => new DateOnly(2022, 1, 1);
        public static TimeOnly StartTime => new TimeOnly(10, 0);
        public static TimeOnly EndTime => new TimeOnly(11, 0);
        public const int MaxParticipants = 10;
    }
}
