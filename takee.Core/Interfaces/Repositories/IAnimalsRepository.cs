using takee.Core.Models;

namespace takee.Core.Interfaces.Repositories
{
    public interface IAnimalsRepository
    {
        Task Create(Animal animal);
        Task Delete(Guid id);
        Task<List<Animal>> Get();
        Task<Animal> GetById(Guid id);
        Task Update(
            Guid id,
            string nickname,
            Guid typeOfAnimalsId,
            Guid breedId,
            int height,
            double weight,
            Gender gender,
            DateTime dateOfBirth,
            string color,
            string distinguishingMark,
            string description,
            Guid curatorId,
            byte[] photo);
    }
}