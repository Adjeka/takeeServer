using takee.Core.Models;

namespace takee.Core.Interfaces.Services
{
    public interface ITypesOfAnimalsService
    {
        Task CreateTypeOfAnimals(TypeOfAnimals typeOfAnimals);
        Task DeleteTypeOfAnimals(Guid id);
        Task<List<TypeOfAnimals>> GetAllTypesOfAnimals();
        Task<TypeOfAnimals> GetTypeOfAnimalsById(Guid id);
        Task UpdateTypeOfAnimals(Guid id, string name);
    }
}