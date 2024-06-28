using takee.Core.Interfaces.Repositories;
using takee.Core.Interfaces.Services;
using takee.Core.Models;

namespace takee.Application.Services
{
    public class AnimalsService : IAnimalsService
    {
        private readonly IAnimalsRepository _animalsRepository;

        public AnimalsService(IAnimalsRepository animalsRepository)
        {
            _animalsRepository = animalsRepository;
        }

        public async Task<List<Animal>> GetAllAnimals()
        {
            return await _animalsRepository.Get();
        }

        public async Task<Animal> GetAnimalById(Guid id)
        {
            return await _animalsRepository.GetById(id);
        }

        public async Task CreateAnimal(Animal animal)
        {
            await _animalsRepository.Create(animal);
        }

        public async Task UpdateAnimal(Guid id,
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
            byte[] photo)
        {
            await _animalsRepository.Update(
                id,
                nickname,
                typeOfAnimalsId,
                breedId,
                height,
                weight,
                gender,
                dateOfBirth,
                color,
                distinguishingMark,
                description,
                curatorId,
                photo);
        }

        public async Task DeleteAnimal(Guid id)
        {
            await _animalsRepository.Delete(id);
        }
    }
}
