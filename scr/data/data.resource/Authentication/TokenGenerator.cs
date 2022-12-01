using ApiResource.Domain.Authentication;
using ApiResource.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ApiResource.Infra.Data.Authentication
{
    public class TokenGenerator : ITokenGenerator
    {
        private static List<(string, string)> _refreshTokens = new();

        public dynamic Generator(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Role)

            };

            var expires = DateTime.Now.AddHours(2);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("projetoDotNetCore6"));

            var tokenData = new JwtSecurityToken(
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
                    expires: expires,
                    claims: claims
                );

            var refreshToken = GenerateRefreshToken();
            SaveRefreshToken(user.Email, refreshToken);

            var token = new JwtSecurityTokenHandler().WriteToken(tokenData);
            return new
            {

                access_token = token,
                expirations = expires,
                email = user.Email,
                refreshToken = refreshToken
            };

        }

        public dynamic Generator(IEnumerable<Claim> claims)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("projetoDotNetCore6");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddHours(4),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("projetoDotNetCore6")),
                ValidateAudience = false,
                ValidateIssuer = false
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);

            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("InvalidToken");

            return principal;
        }

        

        public void SaveRefreshToken(string username, string refreshToken)
        {

            _refreshTokens.Add(new (username, refreshToken));
        }

        public string GetRefreshToken(string username)
        {
            return _refreshTokens.FirstOrDefault(x => x.Item1 == username).Item2;
        }

        public void DeleteRefreshToken(string username, string refreshToken)
        {
            var item = _refreshTokens.FirstOrDefault(x => x.Item1 == username && x.Item2 == refreshToken);
            _refreshTokens.Remove(item);
        }
    }
}
