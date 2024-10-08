﻿using CSharpFunctionalExtensions;

namespace takee.Core.Models
{
    public class User
    {
        public const int MAX_SURNAME_LENGTH = 50;
        public const int MAX_NAME_LENGTH = 50;
        public const int MAX_PATRONYMIC_LENGTH = 50;
        public const int MAX_LOGIN_LENGTH = 15;

        private User(
            Guid id, 
            string surname, 
            string name, 
            string patronymic,
            DateTime dateOfBirth, 
            Email email,
            PhoneNumber phoneNumber,
            UserRole userRole,
            string login,
            string password)
        {
            Id = id;
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            DateOfBirth = dateOfBirth;
            Email = email;
            PhoneNumber = phoneNumber;
            UserRole = userRole;
            Login = login;
            Password = password;
        }

        public Guid Id { get; }
        public string Surname { get; } 
        public string Name { get; }
        public string Patronymic { get; }
        public DateTime DateOfBirth { get; }
        public Email Email { get; }
        public PhoneNumber PhoneNumber { get; }
        public UserRole UserRole { get; }
        public string Login { get; }
        public string Password { get; }

        public static User Create(Guid id,
            string surname,
            string name,
            string patronymic,
            DateTime dateOfBirth,
            Email email,
            PhoneNumber phoneNumber,
            UserRole userRole, 
            string login, 
            string password)
        {
            if (string.IsNullOrEmpty(surname) || surname.Length > MAX_SURNAME_LENGTH)
                throw new ArgumentException($"Surname can not be empty or longer then 50 symbols");

            if (string.IsNullOrEmpty(name) || name.Length > MAX_NAME_LENGTH)
                throw new ArgumentException($"Name can not be empty or longer then 50 symbols");

            if (!string.IsNullOrEmpty(patronymic) && patronymic.Length > MAX_PATRONYMIC_LENGTH)
                throw new ArgumentException($"Patronymic can not longer then 50 symbols");

            if (string.IsNullOrEmpty(login) || login.Length > MAX_LOGIN_LENGTH)
                throw new ArgumentException($"Login can not be empty or longer then 15 symbols");

            if (string.IsNullOrEmpty(password))
                throw new ArgumentException($"Password can not be empty");

            var user = new User(id, surname, name, patronymic, dateOfBirth, email, phoneNumber, userRole, login, password);

            return user;
        }
    }
}