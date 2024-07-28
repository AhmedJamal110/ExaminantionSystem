using ExaminantionSystem.API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExaminantionSystem.API.JwtService
{
    public class JwtProvider : IJwtProvider
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;
        private readonly SymmetricSecurityKey _key ;

        public  JwtProvider( IConfiguration configuration , UserManager<AppUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:Key"]));
        }
        public async Task<string> CreateTokenAsync(AppUser user)
        {

             List<Claim>  claims =
                 [
                     new(JwtRegisteredClaimNames.Sub, user.Id),
                     new(JwtRegisteredClaimNames.Email, user.Email!),
                     new(JwtRegisteredClaimNames.GivenName, user.FirstName),
                     new(JwtRegisteredClaimNames.FamilyName, user.LastName),
                     new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                 ];




            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }


            var token = new JwtSecurityToken
             (

                claims: claims,
                issuer: _configuration["Token:ValidIssuer"],
                audience: _configuration["Token:ValidAudiance"],
                signingCredentials: new SigningCredentials(_key, SecurityAlgorithms.HmacSha256),
                expires: DateTime.Now.AddDays(double.Parse(_configuration["Token:ExpireMinutes"]))
            );



            return  new JwtSecurityTokenHandler().WriteToken(token);
                
                
        }

    }
}

