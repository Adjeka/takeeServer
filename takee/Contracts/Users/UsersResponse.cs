using takee.Core.Models;

namespace takee.Contracts.Users
{
    public record UsersResponse(
        Guid Id,
        string Surname,
        string Name,
        string Patronymic,
        DateTime DateOfBirth,
        string Email,
        string PhoneNumber,
        UserRole UserRole,
        string Login,
        string Password);
}
