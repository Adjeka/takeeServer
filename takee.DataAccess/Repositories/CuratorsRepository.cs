using AutoMapper;
using Microsoft.EntityFrameworkCore;
using takee.Core.Interfaces.Repositories;
using takee.Core.Models;
using takee.DataAccess.Entities;

namespace takee.DataAccess.Repositories
{
    public class CuratorsRepository : ICuratorsRepository
    {
        private readonly TakeeDbContext _context;
        private readonly IMapper _mapper;

        public CuratorsRepository(TakeeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Curator>> Get()
        {
            var curatorEntities = await _context.Curators
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<List<Curator>>(curatorEntities);
        }

        public async Task<Curator> GetById(Guid id)
        {
            var curatorEntity = await _context.Curators
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id) ?? throw new Exception();

            return _mapper.Map<Curator>(curatorEntity);
        }

        public async Task Create(Curator curator)
        {
            var curatorEntity = new CuratorEntity()
            {
                Id = curator.Id,
                Surname = curator.Surname,
                Name = curator.Name,
                Patronymic = curator.Patronymic,
                Email = curator.Email,
                PhoneNumber = curator.PhoneNumber
            };

            await _context.Curators.AddAsync(curatorEntity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Guid id,
            string surname,
            string name,
            string patronymic,
            Email email,
            PhoneNumber phoneNumber)
        {
            var curator = await _context.Curators.FindAsync(id);
            if (curator != null)
            {
                curator.Surname = surname;
                curator.Name = name;
                curator.Patronymic = patronymic;
                curator.Email = email;
                curator.PhoneNumber = phoneNumber;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            await _context.Curators
                .Where(c => c.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
