using CSharpFunctionalExtensions;

namespace takee.Core.Models
{
    public class RecordForWalk
    {
        private RecordForWalk(
            Guid id,
            User user,
            Animal animal,
            DateTime dateOfRecord)
        {
            Id = id;
            User = user;
            Animal = animal;
            DateOfRecord = dateOfRecord;
        }

        public Guid Id { get; }
        public User User { get; }
        public Animal Animal { get; }
        public DateTime DateOfRecord { get; }


        public static Result<RecordForWalk> Create(
            Guid id,
            User user, 
            Animal animal,
            DateTime dateOfRecord)
        {
            var recordForWalk = new RecordForWalk(id, user, animal, dateOfRecord);

            return Result.Success(recordForWalk);
        }
    }
}