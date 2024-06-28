using CSharpFunctionalExtensions;

namespace takee.Core.Models
{
    public class Gender : ValueObject
    {
        public static readonly Gender Male = new(nameof(Male));
        public static readonly Gender Female = new(nameof(Female));

        private static readonly Gender[] _all = [Male, Female];

        public string Value { get; }

        private Gender(string value)
        {
            Value = value;
        }

        public static Result<Gender> Create(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return Result.Failure<Gender>("Gender can not be empty"); 

            var gender = input.Trim().ToLower();

            if (_all.Any(g => g.Value.ToLower() == gender) == false)
                return Result.Failure<Gender>("Gender can be 'Male' or 'Female'");

            var result = new Gender(gender);
            return Result.Success(result);
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
