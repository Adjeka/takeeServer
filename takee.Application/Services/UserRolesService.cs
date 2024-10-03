using takee.Core.Interfaces.Repositories;
using takee.Core.Interfaces.Services;
using takee.Core.Models;

namespace takee.Application.Services
{
    public class UserRolesService : IUserRolesService
    {
        private readonly IUserRolesRepository _userRolesRepository;

        public UserRolesService(IUserRolesRepository userRolesRepository)
        {
            _userRolesRepository = userRolesRepository;
        }

        public async Task<List<UserRole>> GetAllUserRoles()
        {
            return await _userRolesRepository.Get();
        }

        public async Task<UserRole> GetUserRoleById(Guid id)
        {
            return await _userRolesRepository.GetById(id);
        }

        public async Task<UserRole> GetUserRoleByName(string name)
        {
            return await _userRolesRepository.GetByName(name);
        }

        public async Task CreateUserRole(UserRole userRole)
        {
            await _userRolesRepository.Create(userRole);
        }

        public async Task UpdateUserRole(Guid id, string name)
        {
            await _userRolesRepository.Update(id, name);
        }

        public async Task DeleteUserRole(Guid id)
        {
            await _userRolesRepository.Delete(id);
        }
    }
}
