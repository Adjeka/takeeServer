using takee.Core.Models;

namespace takee.Core.Interfaces.Repositories
{
    public interface IFavouritesRepository
    {
        Task Create(Favourite favourite);
        Task Delete(Guid id);
        Task<List<Favourite>> Get();
        Task<Favourite> GetById(Guid id);
        Task Update(Guid id, Guid userId, Guid animalId);
    }
}