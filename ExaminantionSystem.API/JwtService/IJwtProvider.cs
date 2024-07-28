using ExaminantionSystem.API.Entities;

namespace ExaminantionSystem.API.JwtService
{
    public interface IJwtProvider
    {
        Task<string> CreateTokenAsync(AppUser user);
    }
}
