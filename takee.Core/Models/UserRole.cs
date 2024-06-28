using CSharpFunctionalExtensions;

namespace takee.Core.Models
{
    public class UserRole
    {
        public const int MAX_NAME_LENGTH = 50;

        private UserRole(
            Guid id,
            string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }
        public string Name { get; }

        public static Result<UserRole> Create(
            Guid id,
            string name)
        {
            if (string.IsNullOrEmpty(name) || name.Length > MAX_NAME_LENGTH)
                return Result.Failure<UserRole>($"Name of the user role can not be empty or longer then 50 symbols");

            var userRole = new UserRole(id, name);

            return Result.Success(userRole);
        }
    }
}