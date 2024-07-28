using ExaminantionSystem.API.Contracts.Authentacation;

namespace ExaminantionSystem.API.Services
{
    public interface IAuthService
    {
        Task<AuthResponse> GetTokenAsync(string email, string password);
        Task<bool> RegisterAsync(RegisterRequest request);

    }
}
