using takee.Core.Interfaces.Repositories;
using takee.Core.Interfaces.Services;
using takee.Core.Models;

namespace takee.Application.Services
{
    public class BreedsService : IBreedsService
    {
        private readonly IBreedsRepository _breedsRepository;

        public BreedsService(IBreedsRepository breedsRepository)
        {
            _breedsRepository = breedsRepository;
        }

        public async Task<List<Breed>> GetAllBreeds()
        {
            return await _breedsRepository.Get();
        }

        public async Task<Breed> GetBreedById(Guid id)
        {
            return await _breedsRepository.GetById(id);
        }

        public async Task CreateBreed(Breed breed)
        {
            await _breedsRepository.Create(breed);
        }

        public async Task UpdateBreed(Guid id, string name)
        {
            await _breedsRepository.Update(id, name);
        }

        public async Task DeleteBreed(Guid id)
        {
            await _breedsRepository.Delete(id);
        }
    }
}
