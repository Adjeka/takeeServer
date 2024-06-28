using CSharpFunctionalExtensions;

namespace takee.Core.Models
{
    public class Curator
    {
        public const int MAX_SURNAME_LENGTH = 50;
        public const int MAX_NAME_LENGTH = 50;
        public const int MAX_PATRONYMIC_LENGTH = 50;

        private Curator(
            Guid id, 
            string surname, 
            string name, 
            string patronymic,
            Email email,
            PhoneNumber phoneNumber)
        {
            Id = id;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public Guid Id { get; }
        public string Surname { get; }
        public string Name { get; } 
        public string Patronymic { get; }
        public Email Email { get; }
        public PhoneNumber PhoneNumber { get; }

        public static Result<Curator> Create(
            Guid id, 
            string surname, 
            string name, 
            string patronymic, 
            Email email, 
            PhoneNumber phoneNumber)
        {
            if (string.IsNullOrEmpty(surname) || surname.Length > MAX_SURNAME_LENGTH)
                return Result.Failure<Curator>($"Surname can not be empty or longer then 50 symbols");

            if (string.IsNullOrEmpty(name) || name.Length > MAX_NAME_LENGTH)
                return Result.Failure<Curator>($"Name can not be empty or longer then 50 symbols");

            if (string.IsNullOrEmpty(patronymic) || patronymic.Length > MAX_PATRONYMIC_LENGTH)
                return Result.Failure<Curator>($"Patronymic can not be empty or longer then 50 symbols");

            var curator = new Curator(id, surname, name, patronymic, email, phoneNumber);

            return Result.Success(curator);
        }
    }
}