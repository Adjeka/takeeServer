namespace takee.Contracts.Favourites
{
    public record FavouritesRequest(
        Guid UserId,
        Guid AnimalId);
}
