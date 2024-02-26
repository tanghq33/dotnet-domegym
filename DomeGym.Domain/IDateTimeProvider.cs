namespace DomeGym.Domain;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
