using AutoMapper;
using Microsoft.EntityFrameworkCore;
using takee.Core.Interfaces.Repositories;
using takee.Core.Models;
using takee.DataAccess.Entities;

namespace takee.DataAccess.Repositories
{
    public class UserRolesRepository : IUserRolesRepository
    {
        private readonly TakeeDbContext _context;
        private readonly IMapper _mapper;

        public UserRolesRepository(TakeeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UserRole>> Get()
        {
            var userRoleEntities = await _context.UserRoles
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<List<UserRole>>(userRoleEntities);
        }

        public async Task<UserRole> GetById(Guid id)
        {
            var userRoleEntity = await _context.UserRoles
                .AsNoTracking()
                .FirstOrDefaultAsync(ur => ur.Id == id) ?? throw new Exception();

            return _mapper.Map<UserRole>(userRoleEntity);
        }

        public async Task Create(UserRole userRole)
        {
            var userRoleEntity = new UserRoleEntity()
            {
                Id = userRole.Id,
                Name = userRole.Name
            };

            await _context.UserRoles.AddAsync(userRoleEntity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Guid id, string name)
        {
            await _context.UserRoles
                .Where(ur => ur.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(ur => ur.Name, name));
        }

        public async Task Delete(Guid id)
        {
            await _context.UserRoles
                .Where(ur => ur.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
