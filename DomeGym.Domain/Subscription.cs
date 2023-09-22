namespace DomeGym.Domain;

public class Subscription
{
    public required Guid Id { get; init; }
    public List<Gym> Gyms { get; init; } = new();
}