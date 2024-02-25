using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomeGym.Domain.UnitTests.TestUtils.TestConstants;
public partial class Constants
{
    public class User
    {
        public static Guid Id => Guid.NewGuid();
    }
}
