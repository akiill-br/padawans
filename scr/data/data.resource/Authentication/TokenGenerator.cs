using ApiResource.Domain.Authentication;
using ApiResource.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApiResource.Infra.Data.Authentication
{
    public class TokenGenerator : ITokenGenerator
    {
        public dynamic Generator(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("Email", user.Email),
                new Claim("Id", user.Id.ToString())
            };

            var expires = DateTime.Now.AddDays(1);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("projetoDotNetCore6"));
            var tokenData = new JwtSecurityToken(
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
                    expires: expires,
                    claims: claims
                );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenData);
            return new
            {
                access_token = token,
                expirations = expires
            };


        }

    }
}
