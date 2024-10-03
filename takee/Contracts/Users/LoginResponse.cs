using takee.Core.Models;

namespace takee.Contracts.Users
{
    public record LoginResponse(
        string Token,
        User user);
}
