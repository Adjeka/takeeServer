using CSharpFunctionalExtensions;
using System.Text.RegularExpressions;

namespace takee.Core.Models
{
    public class Email : ValueObject
    {
        private const string emailRegex = "^\\S+@\\S+\\.\\S+$";

        public string Mail { get; private set; }

        public Email() { }

        private Email(string email)
        {
            Mail = email;
        }

        public static Result<Email> Create(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return Result.Failure<Email>("Email can not be empty");

            if (Regex.IsMatch(input, emailRegex) == false)
                return Result.Failure<Email>("Incorrectly entered email. Example: username@domain.tld");

            var email = new Email(input);
            return Result.Success(email);
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Mail;
        }
    }
}