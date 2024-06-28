namespace takee.DataAccess.Entities
{
    public class UserRoleEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<UserEntity> Users { get; set; } = [];
    }
}
