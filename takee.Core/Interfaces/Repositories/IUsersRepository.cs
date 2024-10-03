using takee.Core.Models;

namespace takee.Core.Interfaces.Repositories
{
    public interface IUsersRepository
    {
        Task Create(User user);
        Task Delete(Guid id);
        Task<List<User>> Get();
        Task<User> GetById(Guid id);
        Task<User> GetByLogin(string login);
        Task Update(
            Guid id, 
            string surname, 
            string name,
            string patronymic, 
            DateTime dateOfBirth, 
            Email email, 
            PhoneNumber phoneNumber, 
            Guid userRoleId, 
            string login, 
            string password);
    }
}