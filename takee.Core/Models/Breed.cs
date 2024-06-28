using CSharpFunctionalExtensions;

namespace takee.Core.Models
{
    public class Breed
    {
        public const int MAX_NAME_LENGTH = 50;

        private Breed(
            Guid id, 
            string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }
        public string Name { get; } 

        public static Result<Breed> Create(
            Guid id, 
            string name)
        {
            if (string.IsNullOrEmpty(name) || name.Length > MAX_NAME_LENGTH)
                return Result.Failure<Breed>($"Name of the breed can not be empty or longer then 50 symbols");

            var breed = new Breed(id, name);

            return Result.Success(breed);
        }
    }
}