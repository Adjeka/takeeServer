using takee.Core.Interfaces.Repositories;
using takee.Core.Interfaces.Services;
using takee.Core.Models;

namespace takee.Application.Services
{
    public class TypesOfAnimalsService : ITypesOfAnimalsService
    {
        private readonly ITypesOfAnimalsRepository _typesOfAnimalsRepository;

        public TypesOfAnimalsService(ITypesOfAnimalsRepository typesOfAnimalsRepository)
        {
            _typesOfAnimalsRepository = typesOfAnimalsRepository;
        }

        public async Task<List<TypeOfAnimals>> GetAllTypesOfAnimals()
        {
            return await _typesOfAnimalsRepository.Get();
        }

        public async Task<TypeOfAnimals> GetTypeOfAnimalsById(Guid id)
        {
            return await _typesOfAnimalsRepository.GetById(id);
        }

        public async Task CreateTypeOfAnimals(TypeOfAnimals typeOfAnimals)
        {
            await _typesOfAnimalsRepository.Create(typeOfAnimals);
        }

        public async Task UpdateTypeOfAnimals(Guid id, string name)
        {
            await _typesOfAnimalsRepository.Update(id, name);
        }

        public async Task DeleteTypeOfAnimals(Guid id)
        {
            await _typesOfAnimalsRepository.Delete(id);
        }
    }
}
