using System.Xml.Linq;
using takee.Application.Auth;
using takee.Core.Interfaces.Repositories;
using takee.Core.Interfaces.Services;
using takee.Core.Models;

namespace takee.Application.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IJwtProvider _jwtProvider;

        public UsersService(IUsersRepository usersRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
        {
            _usersRepository = usersRepository;
            _passwordHasher = passwordHasher;
            _jwtProvider = jwtProvider;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _usersRepository.Get();
        }

        public async Task<User> GetUserById(Guid id)
        {
            return await _usersRepository.GetById(id);
        }

        public async Task CreateUser(
            string surname,
            string name,
            string patronymic,
            DateTime dateOfBirth,
            string email,
            string phoneNumber,
            UserRole userRole,
            string login,
            string password)
        {
            var emailObject = Email.Create(email);
            var phoneNumberObject = PhoneNumber.Create(phoneNumber);

            var hashedPassword = _passwordHasher.Generate(password);

            var user = User.Create(
                Guid.NewGuid(),
                surname,
                name,
                patronymic,
                dateOfBirth,
                emailObject,
                phoneNumberObject,
                userRole,
                login,
                hashedPassword);

            await _usersRepository.Create(user);
        }

        public async Task UpdateUser(
            Guid id,
            string surname,
            string name,
            string patronymic,
            DateTime dateOfBirth,
            string email,
            string phoneNumber,
            Guid userRoleId,
            string login,
            string password)
        {
            var emailObject = Email.Create(email);
            var phoneNumberObject = PhoneNumber.Create(phoneNumber);

            var hashedPassword = _passwordHasher.Generate(password);

            await _usersRepository.Update(
                id,
                surname,
                name,
                patronymic,
                dateOfBirth,
                emailObject,
                phoneNumberObject,
                userRoleId,
                login,
                hashedPassword);
        }

        public async Task DeleteUser(Guid id)
        {
            await _usersRepository.Delete(id);
        }

        public async Task Register(
            string surname,
            string name,
            string patronymic,
            DateTime dateOfBirth,
            string email,
            string phoneNumber,
            UserRole userRole,
            string login,
            string password)
        {
            var emailObject = Email.Create(email);
            var phoneNumberObject = PhoneNumber.Create(phoneNumber);

            var hashedPassword = _passwordHasher.Generate(password);

            var user = User.Create(
                Guid.NewGuid(),
                surname,
                name,
                patronymic,
                dateOfBirth,
                emailObject,
                phoneNumberObject,
                userRole,
                login,
                hashedPassword);

            await _usersRepository.Create(user);
        }

        public async Task<(string, User)> Login(string login, string password)
        {
            var user = await _usersRepository.GetByLogin(login);

            var result = _passwordHasher.Verify(password, user.Password);

            if (result == false)
            {
                throw new Exception("Failed to login");
            }

            var token = _jwtProvider.Generate(user);

            return (token, user);
        }
    }
}
