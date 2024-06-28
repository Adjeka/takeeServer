using AutoMapper;
using Microsoft.EntityFrameworkCore;
using takee.Core.Interfaces.Repositories;
using takee.Core.Models;
using takee.DataAccess.Entities;

namespace takee.DataAccess.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly TakeeDbContext _context;
        private readonly IMapper _mapper;

        public UsersRepository(TakeeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<User>> Get()
        {
            var userEntities = await _context.Users
                .AsNoTracking()
                .Include(u => u.UserRole)
                .ToListAsync();

            return _mapper.Map<List<User>>(userEntities);
        }

        public async Task<User> GetById(Guid id)
        {
            var userEntity = await _context.Users
                .AsNoTracking()
                .Where(u => u.Id == id)
                .Include(u => u.UserRole)
                .FirstOrDefaultAsync() ?? throw new Exception();

            return _mapper.Map<User>(userEntity);
        }

        public async Task Create(User user)
        {
            var foundUser = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Login == user.Login);

            if (foundUser != null) 
                throw new Exception("Пользователь с таким логином уже зарегистрирован!");


            var userEntity = new UserEntity()
            {
                Id = user.Id,
                Surname = user.Surname,
                Name = user.Name,
                Patronymic = user.Patronymic,
                DateOfBirth = user.DateOfBirth,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                UserRoleId = user.UserRole.Id,
                Login = user.Login,
                Password = user.Password
            };

            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Guid id,
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
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                user.Surname = surname;
                user.Name = name;
                user.Patronymic = patronymic;
                user.DateOfBirth = dateOfBirth;
                user.Email = email;
                user.PhoneNumber = phoneNumber;
                user.UserRoleId = userRoleId;
                user.Login = login;
                user.Password = password;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            await _context.Users
                .Where(u => u.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
