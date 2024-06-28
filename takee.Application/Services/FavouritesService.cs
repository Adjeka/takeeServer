using takee.Core.Interfaces.Repositories;
using takee.Core.Interfaces.Services;
using takee.Core.Models;

namespace takee.Application.Services
{
    public class FavouritesService : IFavouritesService
    {
        private readonly IFavouritesRepository _favouritesRepository;

        public FavouritesService(IFavouritesRepository favouritesRepository)
        {
            _favouritesRepository = favouritesRepository;
        }

        public async Task<List<Favourite>> GetAllFavourites()
        {
            return await _favouritesRepository.Get();
        }

        public async Task<Favourite> GetFavouriteById(Guid id)
        {
            return await _favouritesRepository.GetById(id);
        }

        public async Task CreateFavourite(Favourite favourite)
        {
            await _favouritesRepository.Create(favourite);
        }

        public async Task UpdateFavourite(Guid id, Guid userId, Guid animalId)
        {
            await _favouritesRepository.Update(id, userId, animalId);
        }

        public async Task DeleteFavourite(Guid id)
        {
            await _favouritesRepository.Delete(id);
        }
    }
}
