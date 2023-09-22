namespace DomeGym.Domain;

public class Gym
{
    public required Guid Id { get; init; }
    public List<Room> Rooms { get; init; } = new();
}