using AutoMapper;
using Microsoft.EntityFrameworkCore;
using takee.Core.Interfaces.Repositories;
using takee.Core.Models;
using takee.DataAccess.Entities;

namespace takee.DataAccess.Repositories
{
    public class FavouritesRepository : IFavouritesRepository
    {
        private readonly TakeeDbContext _context;
        private readonly IMapper _mapper;

        public FavouritesRepository(TakeeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Favourite>> Get()
        {
            var favouriteEntities = await _context.Favourites
                .AsNoTracking()
                .Include(f => f.User)
                .Include(f => f.Animal)
                .ToListAsync();

            return _mapper.Map<List<Favourite>>(favouriteEntities);
        }

        public async Task<Favourite> GetById(Guid id)
        {
            var favouriteEntity = await _context.Favourites
                .AsNoTracking()
                .Where(f => f.Id == id)
                .Include(f => f.User)
                .Include(f => f.Animal)
                .FirstOrDefaultAsync() ?? throw new Exception();

            return _mapper.Map<Favourite>(favouriteEntity);
        }

        public async Task Create(Favourite favourite)
        {
            var favouriteEntity = new FavouriteEntity()
            {
                Id = favourite.Id,
                UserId = favourite.User.Id,
                AnimalId = favourite.Animal.Id
            };

            await _context.Favourites.AddAsync(favouriteEntity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Guid id, Guid userId, Guid animalId)
        {
            await _context.Favourites
                .Where(f => f.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(f => f.UserId, userId)
                    .SetProperty(f => f.AnimalId, animalId));
        }

        public async Task Delete(Guid id)
        {
            await _context.Favourites
                .Where(f => f.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
