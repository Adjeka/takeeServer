namespace takee.Contracts.Users
{
    public record UsersRequest(
        string Surname,
        string Name,
        string Patronymic,
        DateTime DateOfBirth,
        string Email,
        string PhoneNumber,
        Guid UserRoleId,
        string Login,
        string Password);
}
