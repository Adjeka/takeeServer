using takee.Core.Models;

namespace takee.Core.Interfaces.Repositories
{
    public interface ITypesOfAnimalsRepository
    {
        Task Create(TypeOfAnimals typeOfAnimals);
        Task Delete(Guid id);
        Task<List<TypeOfAnimals>> Get();
        Task<TypeOfAnimals> GetById(Guid id);
        Task Update(Guid id, string name);
    }
}