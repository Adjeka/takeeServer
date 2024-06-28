namespace takee.DataAccess.Entities
{
    public class BreedEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<AnimalEntity> Animals { get; set; } = [];
    }
}
