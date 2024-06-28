using takee.Core.Models;

namespace takee.DataAccess.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Surname { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Patronymic { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public Email Email { get; set; } = null!;
        public PhoneNumber PhoneNumber { get; set; } = null!;
        public Guid UserRoleId { get; set; }
        public UserRoleEntity UserRole { get; set; } = null!;
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public List<FavouriteEntity> Favorites { get; set; } = [];
        public List<RecordForWalkEntity> RecordsForWalk { get; set; } = [];
    }
}
