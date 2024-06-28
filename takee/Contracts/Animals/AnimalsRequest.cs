namespace takee.Contracts.Animals
{
    public record AnimalsRequest(
        string Nickname,
        Guid TypeOfAnimalsId,
        Guid BreedId,
        int Height,
        double Weight,
        string Gender,
        DateTime DateOfBirth,
        string Color,
        string DistinguishingMark,
        string Description,
        Guid CuratorId,
        IFormFile? Photo);
}
