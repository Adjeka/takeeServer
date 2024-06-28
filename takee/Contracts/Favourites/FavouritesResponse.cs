using takee.Core.Models;

namespace takee.Contracts.Favourites
{
    public record FavouritesResponse(
        Guid Id,
        User User,
        Animal Animal);
}
