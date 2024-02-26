using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomeGym.Domain.UnitTests.TestUtils.Services;

public class TestDateTimeProvider : IDateTimeProvider
{
    private readonly DateTime? _fixedDateTime;
    public DateTime UtcNow => _fixedDateTime ?? DateTime.UtcNow;

    public TestDateTimeProvider(DateTime? fixedDateTime = null)
    {
        _fixedDateTime = fixedDateTime;
    }
}
