using CSharpFunctionalExtensions;

namespace takee.Core.Models
{
    public class Age : ValueObject
    {
        public int Years { get; }

        public int Months { get; }

        private Age(int years, int months)
        {
            Years = years;
            Months = months;
        }

        public static Result<Age> Create(int years, int months)
        {
            if (years <= 0)
                return Result.Failure<Age>("Years can not be less than 0");

            if (months is <= 0 or > 12)
                return Result.Failure<Age>("Months must be from 0 to 12");

            var age = new Age(years, months);

            return Result.Success(age);
        }

        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Years;
            yield return Months;
        }
    }
}