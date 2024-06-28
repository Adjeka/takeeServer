using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;

namespace takee.Core.Models
{
    public class PhoneNumber : ValueObject
    {
        private const string phoneRegex = @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$";

        public string Number { get; }

        private PhoneNumber(string number)
        {
            Number = number;
        }

        public static Result<PhoneNumber> Create(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return Result.Failure<PhoneNumber>("Phone number can not be empty");

            if (Regex.IsMatch(input, phoneRegex) == false)
                return Result.Failure<PhoneNumber>("Incorrectly entered phone number");

            var phoneNumber = new PhoneNumber(input);
            return Result.Success(phoneNumber);
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Number;
        }
    }
}