using takee.Core.Models;

namespace takee.DataAccess.Entities
{
    public class CuratorEntity
    {
        public Guid Id { get; set; }
        public string Surname { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Patronymic { get; set; } = string.Empty;
        public Email Email { get; set; } = null!;
        public PhoneNumber PhoneNumber { get; set; } = null!;

        public List<AnimalEntity> Animals { get; set; } = [];
    }
}
