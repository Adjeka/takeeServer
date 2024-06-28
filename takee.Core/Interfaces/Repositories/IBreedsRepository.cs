using takee.Core.Models;

namespace takee.Core.Interfaces.Repositories
{
    public interface IBreedsRepository
    {
        Task Create(Breed breed);
        Task Delete(Guid id);
        Task<List<Breed>> Get();
        Task<Breed> GetById(Guid id);
        Task Update(Guid id, string name);
    }
}