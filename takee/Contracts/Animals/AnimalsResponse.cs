using takee.Core.Models;

namespace takee.Contracts.Animals
{
    public record AnimalsResponse(
        Guid Id,
        string Nickname,
        TypeOfAnimals TypeOfAnimals,
        Breed Breed,
        int Height,
        double Weight,
        string Gender,
        DateTime DateOfBirth,
        string Color,
        string DistinguishingMark,
        string Description,
        Curator Curator,
        string Photo);
}
