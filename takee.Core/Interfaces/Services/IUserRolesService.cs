using takee.Core.Models;

namespace takee.Core.Interfaces.Services
{
    public interface IUserRolesService
    {
        Task CreateUserRole(UserRole userRole);
        Task DeleteUserRole(Guid id);
        Task<List<UserRole>> GetAllUserRoles();
        Task<UserRole> GetUserRoleById(Guid id);
        Task UpdateUserRole(Guid id, string name);
    }
}