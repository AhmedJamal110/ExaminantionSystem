using ExaminantionSystem.API.Contracts.Authentacation;
using ExaminantionSystem.API.Entities;
using ExaminantionSystem.API.JwtService;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;

namespace ExaminantionSystem.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IJwtProvider _jwtProvider;

        public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJwtProvider jwtProvider)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtProvider = jwtProvider;
        }
        public async Task<AuthResponse> GetTokenAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user is null)
                return null;

            var result = await _signInManager.PasswordSignInAsync(user, password, false, false);
            if (result.Succeeded)
            {
                var token = await _jwtProvider.CreateTokenAsync(user);

                var response = new AuthResponse()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Token = token
                };


                return response;
            }

            return null;
        }

        public async Task<bool> RegisterAsync(RegisterRequest request)
        {
            var user = new AppUser()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                UserName = request.Email.Split("@")[0]
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Student");
                 
                return true;
            }




            return false;
        }
    }


}
