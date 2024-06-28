using takee.Core.Models;

namespace takee.Core.Interfaces.Repositories
{
    public interface IRecordsForWalkRepository
    {
        Task Create(RecordForWalk recordForWalk);
        Task Delete(Guid id);
        Task<List<RecordForWalk>> Get();
        Task<RecordForWalk> GetById(Guid id);
        Task Update(Guid id, Guid userId, Guid animalId, DateTime dateOfRecord);
    }
}