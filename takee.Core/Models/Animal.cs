using CSharpFunctionalExtensions;

namespace takee.Core.Models
{
    public class Animal
    {
        public const int MAX_NICKNAME_LENGTH = 50;
        public const int MAX_COLOR_LENGTH = 50;
        public const int MAX_DISTINGUISHINGMARK_LENGTH = 250;
        public const int MAX_DESCRIPTION_LENGTH = 1000;

        private Animal(
            Guid id, 
            string nickname,
            TypeOfAnimals typeOfAnimals, 
            Breed breed, 
            int height,
            double weight,
            Gender gender,
            DateTime dateOfBirth, 
            string color,
            string distinguishingMark,
            string description,
            Curator curator,
            byte[] photo)
        {
            Id = id;
            Nickname = nickname;
            TypeOfAnimals = typeOfAnimals;
            Breed = breed;
            Height = height;
            Weight = weight;
            Gender = gender;
            DateOfBirth = dateOfBirth; 
            Color = color;
            DistinguishingMark = distinguishingMark;
            Description = description;
            Curator = curator;
            Photo = photo;
        }

        public Guid Id { get; }
        public string Nickname { get; }
        public TypeOfAnimals TypeOfAnimals { get; } 
        public Breed Breed { get; }
        public int Height { get; }
        public double Weight { get; }
        public Gender Gender { get; } 
        public DateTime DateOfBirth { get; }
        public string Color { get; }
        public string DistinguishingMark { get; }
        public string Description { get; }
        public Curator Curator { get; }
        public byte[] Photo { get; } = [];

        public static Result<Animal> Create(
            Guid id,
            string nickname,
            TypeOfAnimals typeOfAnimals,
            Breed breed,
            int height,
            double weight,
            Gender gender,
            DateTime dateOfBirth,
            string color,
            string distinguishingMark,
            string description,
            Curator curator, 
            byte[] photo)
        {
            if (string.IsNullOrEmpty(nickname) || nickname.Length > MAX_NICKNAME_LENGTH)
                return Result.Failure<Animal>($"Nickname can not be empty or longer then 50 symbols");

            if(height < 0)
                return Result.Failure<Animal>($"Height can not be less than 0");

            if (weight < 0)
                return Result.Failure<Animal>($"Weight can not be less than 0");

            if (string.IsNullOrEmpty(color) || color.Length > MAX_COLOR_LENGTH)
                return Result.Failure<Animal>($"Color can not be empty or longer then 50 symbols");

            if (string.IsNullOrEmpty(distinguishingMark) || distinguishingMark.Length > MAX_DISTINGUISHINGMARK_LENGTH)
                return Result.Failure<Animal>($"Description can not be empty or longer then 250 symbols");

            if (string.IsNullOrEmpty(description) || description.Length > MAX_DESCRIPTION_LENGTH)
                return Result.Failure<Animal>($"Description can not be empty or longer then 1000 symbols");

            var animal = 
                new Animal(id, nickname, typeOfAnimals, breed, height, weight, gender, dateOfBirth, color, distinguishingMark, description, curator, photo);

            return Result.Success(animal);
        }
    }
}