using CSharpFunctionalExtensions;

namespace takee.Core.Models
{
    public class Favourite
    {
        private Favourite(
            Guid id,
            User user,
            Animal animal)
        {
            Id = id;
            User = user;
            Animal = animal;
        }

        public Guid Id { get; }
        public User User { get; }
        public Animal Animal { get; }

        public static Result<Favourite> Create(
            Guid id,
            User user,
            Animal animal)
        {
            var favourite = new Favourite(id, user, animal);

            return Result.Success(favourite);
        }
    }
}