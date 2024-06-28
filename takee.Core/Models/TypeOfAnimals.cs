using CSharpFunctionalExtensions;

namespace takee.Core.Models
{
    public class TypeOfAnimals
    {
        public const int MAX_NAME_LENGTH = 50;

        private TypeOfAnimals(
            Guid id, 
            string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; }
        public string Name { get; }

        public static Result<TypeOfAnimals> Create(
            Guid id, 
            string name)
        {
            if (string.IsNullOrEmpty(name) || name.Length > MAX_NAME_LENGTH)
                return Result.Failure<TypeOfAnimals>($"Name of the type of animal can not be empty or longer then 50 symbols");

            var typeOfAnimals = new TypeOfAnimals(id, name);

            return Result.Success(typeOfAnimals);
        }
    }
}