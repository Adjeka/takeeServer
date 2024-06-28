using takee.Core.Models;

namespace takee.Core.Interfaces.Services
{
    public interface IAnimalsService
    {
        Task CreateAnimal(Animal animal);
        Task DeleteAnimal(Guid id);
        Task<List<Animal>> GetAllAnimals();
        Task<Animal> GetAnimalById(Guid id);
        Task UpdateAnimal(Guid id, string nickname, Guid typeOfAnimalsId, Guid breedId, int height, double weight, Gender gender, DateTime dateOfBirth, string color, string distinguishingMark, string description, Guid curatorId, byte[] photo);
    }
}