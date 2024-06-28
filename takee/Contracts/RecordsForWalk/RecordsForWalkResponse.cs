using takee.Core.Models;

namespace takee.Contracts.RecordsForWalk
{
    public record RecordsForWalkResponse(
        Guid Id,
        User User,
        Animal Animal,
        DateTime DateOfRecord);
}
