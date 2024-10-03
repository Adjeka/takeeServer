using takee.Core.Models;

namespace takee.Core.Interfaces.Repositories
{
    public interface IFavouritesRepository
    {
        Task Create(Favourite favourite);
        Task Delete(Guid id);
        Task<List<Favourite>> Get();
        Task<Favourite> GetById(Guid id);
        Task<List<Favourite>> GetByUserId(Guid id);
        Task<Favourite> GetByUserIdAndAnimalId(Guid userId, Guid animalId);
        Task Update(Guid id, Guid userId, Guid animalId);
    }
}