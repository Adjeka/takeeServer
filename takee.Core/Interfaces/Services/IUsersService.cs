using takee.Core.Models;

namespace takee.Core.Interfaces.Services
{
    public interface IUsersService
    {
        Task CreateUser(
            string surname,
            string name,
            string patronymic,
            DateTime dateOfBirth,
            string email,
            string phoneNumber,
            UserRole userRole,
            string login,
            string password);
        Task DeleteUser(Guid id);
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(Guid id);
        Task UpdateUser(
            Guid id, 
            string surname, 
            string name, 
            string patronymic, 
            DateTime dateOfBirth, 
            string email,
            string phoneNumber, 
            Guid userRoleId, 
            string login, 
            string password);
        Task<(string, User)> Login(string login, string password);
        Task Register(
            string surname,
            string name,
            string patronymic,
            DateTime dateOfBirth,
            string email,
            string phoneNumber,
            UserRole userRole,
            string login,
            string password);
    }
}