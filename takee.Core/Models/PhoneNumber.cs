using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;

namespace takee.Core.Models
{
    public class PhoneNumber : ValueObject
    {
        private const string phoneRegex = @"^(\+7|7|8)?[\s\-]?\(?\d{3}\)?[\s\-]?\d{3}[\s\-]?\d{2}[\s\-]?\d{2}$";

        public string Number { get; }

        private PhoneNumber(string number)
        {
            Number = number;
        }

        public static PhoneNumber Create(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Phone number can not be empty");

            if (Regex.IsMatch(input, phoneRegex) == false)
                throw new ArgumentException("Incorrectly entered phone number");

            var phoneNumber = new PhoneNumber(input);
            return phoneNumber;
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Number;
        }
    }
}