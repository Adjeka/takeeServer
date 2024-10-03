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

        public static Email Create(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Email can not be empty");

            if (Regex.IsMatch(input, emailRegex) == false)
                throw new ArgumentException("Incorrectly entered email. Example: username@domain.tld");

            var email = new Email(input);
            return email;
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Mail;
        }
    }
}