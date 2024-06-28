using AutoMapper;
using Microsoft.EntityFrameworkCore;
using takee.Core.Interfaces.Repositories;
using takee.Core.Models;
using takee.DataAccess.Entities;

namespace takee.DataAccess.Repositories
{
    public class RecordsForWalkRepository : IRecordsForWalkRepository
    {
        private readonly TakeeDbContext _context;
        private readonly IMapper _mapper;

        public RecordsForWalkRepository(TakeeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<RecordForWalk>> Get()
        {
            var recordForWalkEntities = await _context.RecordsForWalk
                .AsNoTracking()
                .Include(r => r.User)
                .Include(r => r.Animal)
                .ToListAsync();

            return _mapper.Map<List<RecordForWalk>>(recordForWalkEntities);
        }

        public async Task<RecordForWalk> GetById(Guid id)
        {
            var recordForWalkEntity = await _context.RecordsForWalk
                .AsNoTracking()
                .Where(r => r.Id == id)
                .Include(r => r.User)
                .Include(r => r.Animal)
                .FirstOrDefaultAsync() ?? throw new Exception();

            return _mapper.Map<RecordForWalk>(recordForWalkEntity);
        }

        public async Task Create(RecordForWalk recordForWalk)
        {
            var recordForWalkEntity = new RecordForWalkEntity()
            {
                Id = recordForWalk.Id,
                UserId = recordForWalk.User.Id,
                AnimalId = recordForWalk.Animal.Id
            };

            await _context.RecordsForWalk.AddAsync(recordForWalkEntity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Guid id, Guid userId, Guid animalId, DateTime dateOfRecord)
        {
            await _context.RecordsForWalk
                .Where(r => r.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(r => r.UserId, userId)
                    .SetProperty(r => r.AnimalId, animalId)
                    .SetProperty(r => r.DateOfRecord, dateOfRecord));
        }

        public async Task Delete(Guid id)
        {
            await _context.RecordsForWalk
                .Where(r => r.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
