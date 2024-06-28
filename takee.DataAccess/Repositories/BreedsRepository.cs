using AutoMapper;
using Microsoft.EntityFrameworkCore;
using takee.Core.Interfaces.Repositories;
using takee.Core.Models;
using takee.DataAccess.Entities;

namespace takee.DataAccess.Repositories
{
    public class BreedsRepository : IBreedsRepository
    {
        private readonly TakeeDbContext _context;
        private readonly IMapper _mapper;

        public BreedsRepository(TakeeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Breed>> Get()
        {
            var breedEntities = await _context.Breeds
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<List<Breed>>(breedEntities);
        }

        public async Task<Breed> GetById(Guid id)
        {
            var breedEntity = await _context.Breeds
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id) ?? throw new Exception();

            return _mapper.Map<Breed>(breedEntity);
        }

        public async Task Create(Breed breed)
        {
            var breedEntity = new BreedEntity()
            {
                Id = breed.Id,
                Name = breed.Name
            };

            await _context.Breeds.AddAsync(breedEntity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Guid id, string name)
        {
            await _context.Breeds
                .Where(b => b.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.Name, name));
        }

        public async Task Delete(Guid id)
        {
            await _context.Breeds
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
