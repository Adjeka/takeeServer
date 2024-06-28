using takee.Core.Models;

namespace takee.Core.Interfaces.Services
{
    public interface IBreedsService
    {
        Task CreateBreed(Breed breed);
        Task DeleteBreed(Guid id);
        Task<List<Breed>> GetAllBreeds();
        Task<Breed> GetBreedById(Guid id);
        Task UpdateBreed(Guid id, string name);
    }
}