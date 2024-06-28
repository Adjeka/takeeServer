using takee.Core.Models;

namespace takee.Core.Interfaces.Repositories
{
    public interface IUserRolesRepository
    {
        Task Create(UserRole userRole);
        Task Delete(Guid id);
        Task<List<UserRole>> Get();
        Task<UserRole> GetById(Guid id);
        Task Update(Guid id, string name);
    }
}