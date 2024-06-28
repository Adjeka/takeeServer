using AutoMapper;
using Microsoft.EntityFrameworkCore;
using takee.Core.Interfaces.Repositories;
using takee.Core.Models;
using takee.DataAccess.Entities;

namespace takee.DataAccess.Repositories
{
    public class AnimalsRepository : IAnimalsRepository
    {
        private readonly TakeeDbContext _context;
        private readonly IMapper _mapper;

        public AnimalsRepository(TakeeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Animal>> Get()
        {
            var animalEntities = await _context.Animals
                .AsNoTracking()
                .Include(a => a.TypeOfAnimals)
                .Include(a => a.Breed)
                .Include(a => a.Curator)
                .ToListAsync();

            return _mapper.Map<List<Animal>>(animalEntities);
        }

        public async Task<Animal> GetById(Guid id)
        {
            var animalEntity = await _context.Animals
                .AsNoTracking()
                .Where(a => a.Id == id)
                .Include(a => a.TypeOfAnimals)
                .Include(a => a.Breed)
                .Include(a => a.Curator)
                .FirstOrDefaultAsync() ?? throw new Exception();

            return _mapper.Map<Animal>(animalEntity);
        }

        public async Task Create(Animal animal)
        {
            var animalEntity = new AnimalEntity()
            {
                Id = animal.Id,
                Nickname = animal.Nickname,
                TypeOfAnimalsId = animal.TypeOfAnimals.Id,
                BreedId = animal.Breed.Id,
                Height = animal.Height,
                Weight = animal.Weight,
                Gender = animal.Gender,
                DateOfBirth = animal.DateOfBirth,
                Color = animal.Color,
                DistinguishingMark = animal.DistinguishingMark,
                Description = animal.Description,
                CuratorId = animal.Curator.Id,
                Photo = animal.Photo
            };

            await _context.Animals.AddAsync(animalEntity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Guid id,
            string nickname,
            Guid typeOfAnimalsId,
            Guid breedId,
            int height,
            double weight,
            Gender gender,
            DateTime dateOfBirth,
            string color,
            string distinguishingMark,
            string description,
            Guid curatorId,
            byte[] photo)
        {
            var animal = await _context.Animals.FindAsync(id);
            if (animal != null)
            {
                animal.Nickname = nickname;
                animal.TypeOfAnimalsId = typeOfAnimalsId;
                animal.BreedId = breedId;
                animal.Height = height;
                animal.Weight = weight;
                animal.Gender = gender;
                animal.DateOfBirth = dateOfBirth;
                animal.Color = color;
                animal.DistinguishingMark = distinguishingMark;
                animal.Description = description;
                animal.CuratorId = curatorId;
                animal.Photo = photo;

                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            await _context.Animals
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync();
        }
    }
}
