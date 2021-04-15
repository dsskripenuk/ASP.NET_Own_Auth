using Auth.DataAccess;
using Auth.DataAccess.Entity;
using Auth.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Auth.Domain.Implementations
{
    public class JWTTokenService : IJWTTokenService
    {
        private readonly EFContext _context;
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;

        public JWTTokenService(
            EFContext context,
            IConfiguration configuration,
            UserManager<User> userManager
            )
        {
            _configuration = configuration;
            _context = context;
            _userManager = userManager;
        }

        public string CreateToken(User user)
        {
            var roles = _userManager.GetRolesAsync(user).Result;

            var claims = new List<Claim>
            {
                new Claim("id", user.Id),
                new Claim("email", user.Email)
            };

            foreach (var role in roles)
                claims.Add(new Claim("roles", role));

            string jwtTokenSecretKey = _configuration["SecretPhrase"];
            var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtTokenSecretKey));
            var signInCredentials = new SigningCredentials(signInKey, SecurityAlgorithms.HmacSha256);

            var jwtToken = new JwtSecurityToken(
                    signingCredentials: signInCredentials,
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(14)
                );

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
