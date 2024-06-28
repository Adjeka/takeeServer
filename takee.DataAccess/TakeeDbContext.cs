using Microsoft.EntityFrameworkCore;
using takee.DataAccess.Configurations;
using takee.DataAccess.Entities;

namespace takee.DataAccess
{
    public class TakeeDbContext(DbContextOptions<TakeeDbContext> options) 
        : DbContext(options)
    {
        public DbSet<AnimalEntity> Animals { get; set; }
        public DbSet<BreedEntity> Breeds { get; set; }
        public DbSet<CuratorEntity> Curators { get; set; }
        public DbSet<FavouriteEntity> Favourites { get; set; }
        public DbSet<RecordForWalkEntity> RecordsForWalk { get; set; }
        public DbSet<TypeOfAnimalsEntity> TypesOfAnimals { get; set; }
        public DbSet<UserRoleEntity> UserRoles { get; set; }
        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AnimalConfiguration());
            modelBuilder.ApplyConfiguration(new BreedConfiguration());
            modelBuilder.ApplyConfiguration(new CuratorConfiguration());
            modelBuilder.ApplyConfiguration(new FavouriteConfiguration());
            modelBuilder.ApplyConfiguration(new RecordForWalkConfiguration()); 
            modelBuilder.ApplyConfiguration(new TypeOfAnimalsConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        }
    }
}