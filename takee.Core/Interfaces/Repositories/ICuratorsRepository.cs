using takee.Core.Models;

namespace takee.Core.Interfaces.Repositories
{
    public interface ICuratorsRepository
    {
        Task Create(Curator curator);
        Task Delete(Guid id);
        Task<List<Curator>> Get();
        Task<Curator> GetById(Guid id);
        Task Update(Guid id, string surname, string name, string patronymic, Email email, PhoneNumber phoneNumber);
    }
}