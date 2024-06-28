using takee.Core.Models;

namespace takee.Core.Interfaces.Services
{
    public interface IUsersService
    {
        Task CreateUser(User user);
        Task DeleteUser(Guid id);
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(Guid id);
        Task UpdateUser(Guid id, string surname, string name, string patronymic, DateTime dateOfBirth, Email email, PhoneNumber phoneNumber, Guid userRoleId, string login, string password);
    }
}