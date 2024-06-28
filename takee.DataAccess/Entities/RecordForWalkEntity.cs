using takee.Core.Models;

namespace takee.DataAccess.Entities
{
    public class RecordForWalkEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public UserEntity User { get; set; } = null!;
        public Guid AnimalId { get; set; }
        public AnimalEntity Animal { get; set; } = null!;
        public DateTime DateOfRecord { get; set; }
    }
}
