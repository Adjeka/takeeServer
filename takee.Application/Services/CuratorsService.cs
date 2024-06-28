using takee.Core.Interfaces.Repositories;
using takee.Core.Interfaces.Services;
using takee.Core.Models;

namespace takee.Application.Services
{
    public class CuratorsService : ICuratorsService
    {
        private readonly ICuratorsRepository _curatorsRepository;

        public CuratorsService(ICuratorsRepository curatorsRepository)
        {
            _curatorsRepository = curatorsRepository;
        }

        public async Task<List<Curator>> GetAllCurators()
        {
            return await _curatorsRepository.Get();
        }

        public async Task<Curator> GetCuratorById(Guid id)
        {
            return await _curatorsRepository.GetById(id);
        }

        public async Task CreateCurator(Curator curator)
        {
            await _curatorsRepository.Create(curator);
        }

        public async Task UpdateCurator(Guid id, string surname, string name, string patronymic, Email email, PhoneNumber phoneNumber)
        {
            await _curatorsRepository.Update(id, surname, name, patronymic, email, phoneNumber);
        }

        public async Task DeleteCurator(Guid id)
        {
            await _curatorsRepository.Delete(id);
        }
    }
}
