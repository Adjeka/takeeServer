using takee.Core.Models;

namespace takee.Core.Interfaces.Services
{
    public interface IFavouritesService
    {
        Task CreateFavourite(Favourite favourite);
        Task DeleteFavourite(Guid id);
        Task<List<Favourite>> GetAllFavourites();
        Task<Favourite> GetFavouriteById(Guid id);
        Task UpdateFavourite(Guid id, Guid userId, Guid animalId);
    }
}