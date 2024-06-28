using AutoMapper;
using Microsoft.EntityFrameworkCore;
using takee.Core.Interfaces.Repositories;
using takee.Core.Models;
using takee.DataAccess.Entities;

namespace takee.DataAccess.Repositories
{
    public class TypesOfAnimalsRepository : ITypesOfAnimalsRepository
    {
        private readonly TakeeDbContext _context;
        private readonly IMapper _mapper;

        public TypesOfAnimalsRepository(TakeeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TypeOfAnimals>> Get()
        {
            var typeOfAnimalsEntities = await _context.TypesOfAnimals
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<List<TypeOfAnimals>>(typeOfAnimalsEntities);
        }

        public async Task<TypeOfAnimals> GetById(Guid id)
        {
            var typeOfAnimalsEntity = await _context.TypesOfAnimals
                .AsNoTracking()
                .FirstOrDefaultAsync(t => t.Id == id) ?? throw new Exception();

            return _mapper.Map<TypeOfAnimals>(typeOfAnimalsEntity);
        }

        public async Task Create(TypeOfAnimals typeOfAnimals)
        {
            var typeOfAnimalsEntity = new TypeOfAnimalsEntity()
            {
                Id = typeOfAnimals.Id,
                Name = typeOfAnimals.Name
            };

            await _context.TypesOfAnimals.AddAsync(typeOfAnimalsEntity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Guid id, string name)
        {
            await _context.TypesOfAnimals
                .Where(t => t.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(t => t.Name, name));
        }

        public async Task Delete(Guid id)
        {
            await _context.TypesOfAnimals
                .Where(t => t.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
