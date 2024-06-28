using takee.Core.Interfaces.Repositories;
using takee.Core.Interfaces.Services;
using takee.Core.Models;

namespace takee.Application.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _usersRepository.Get();
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await _usersRepository.GetById(id);
        }

        public async Task CreateUser(User user)
        {
            await _usersRepository.Create(user);
        }

        public async Task UpdateUser(
            Guid id,
            string surname,
            string name,
            string patronymic,
            DateTime dateOfBirth,
            Email email,
            PhoneNumber phoneNumber,
            Guid userRoleId,
            string login,
            string password)
        {
            await _usersRepository.Update(
                id,
                surname,
                name,
                patronymic,
                dateOfBirth,
                email,
                phoneNumber,
                userRoleId,
                login,
                password);
        }

        public async Task DeleteUser(Guid id)
        {
            await _usersRepository.Delete(id);
        }
    }
}
