using takee.Core.Models;

namespace takee.Core.Interfaces.Services
{
    public interface ICuratorsService
    {
        Task CreateCurator(Curator curator);
        Task DeleteCurator(Guid id);
        Task<List<Curator>> GetAllCurators();
        Task<Curator> GetCuratorById(Guid id);
        Task UpdateCurator(Guid id, string surname, string name, string patronymic, Email email, PhoneNumber phoneNumber);
    }
}