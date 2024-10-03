namespace takee.Contracts.Users
{
    public record RegisterUserRequest(
        string Surname,
        string Name,
        string Patronymic,
        DateTime DateOfBirth,
        string Email,
        string PhoneNumber,
        string Login,
        string Password);
}