using takee.Core.Models;

namespace takee.Contracts.Curators
{
    public record CuratorsResponse(
        Guid Id,
        string Surname,
        string Name,
        string Patronymic,
        string Email,
        string PhoneNumber);
}
