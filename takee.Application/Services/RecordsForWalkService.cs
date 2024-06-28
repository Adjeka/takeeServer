using takee.Core.Interfaces.Repositories;
using takee.Core.Interfaces.Services;
using takee.Core.Models;

namespace takee.Application.Services
{
    public class RecordsForWalkService : IRecordsForWalkService
    {
        private readonly IRecordsForWalkRepository _recordsForWalkRepository;

        public RecordsForWalkService(IRecordsForWalkRepository recordsForWalkRepository)
        {
            _recordsForWalkRepository = recordsForWalkRepository;
        }

        public async Task<List<RecordForWalk>> GetAllRecordsForWalk()
        {
            return await _recordsForWalkRepository.Get();
        }

        public async Task<RecordForWalk> GetRecordForWalkById(Guid id)
        {
            return await _recordsForWalkRepository.GetById(id);
        }

        public async Task CreateRecordForWalk(RecordForWalk recordForWalk)
        {
            await _recordsForWalkRepository.Create(recordForWalk);
        }

        public async Task UpdateRecordForWalk(Guid id, Guid userId, Guid animalId, DateTime dateOfRecord)
        {
            await _recordsForWalkRepository.Update(id, userId, animalId, dateOfRecord);
        }

        public async Task DeleteRecordForWalk(Guid id)
        {
            await _recordsForWalkRepository.Delete(id);
        }
    }
}
