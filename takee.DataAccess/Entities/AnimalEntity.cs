using takee.Core.Models;

namespace takee.DataAccess.Entities
{
    public class AnimalEntity
    {
        public Guid Id { get; set; }
        public string Nickname { get; set; } = string.Empty;
        public Guid TypeOfAnimalsId { get; set; }
        public TypeOfAnimalsEntity TypeOfAnimals { get; set; } = null!;
        public Guid BreedId { get; set; }
        public BreedEntity Breed { get; set; } = null!;
        public int Height { get; set; }
        public double Weight { get; set; }
        public Gender Gender { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string Color { get; set; } = string.Empty;
        public string DistinguishingMark { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid CuratorId { get; set; }
        public CuratorEntity Curator { get; set; } = null!;
        public byte[] Photo { get; set; } = [];

        public List<FavouriteEntity> Favorites { get; set; } = [];
        public List<RecordForWalkEntity> RecordsForWalk { get; set; } = [];
    }
}
