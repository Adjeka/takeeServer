using takee.Core.Models;

namespace takee.Application.Auth
{
    public interface IJwtProvider
    {
        string Generate(User user);
    }
}
