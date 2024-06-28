using takee.Core.Models;

namespace takee.Core.Interfaces.Services
{
    public interface IRecordsForWalkService
    {
        Task CreateRecordForWalk(RecordForWalk recordForWalk);
        Task DeleteRecordForWalk(Guid id);
        Task<List<RecordForWalk>> GetAllRecordsForWalk();
        Task<RecordForWalk> GetRecordForWalkById(Guid id);
        Task UpdateRecordForWalk(Guid id, Guid userId, Guid animalId, DateTime dateOfRecord);
    }
}