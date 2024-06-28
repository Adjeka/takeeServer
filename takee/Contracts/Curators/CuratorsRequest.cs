namespace takee.Contracts.Curators
{
    public record CuratorsRequest(
        string Surname,
        string Name,
        string Patronymic,
        string Email,
        string PhoneNumber);
}
