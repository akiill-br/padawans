using ApiResource.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApiResource.Domain.Authentication
{
    public interface ITokenGenerator
    {
        dynamic Generator(User user);
        dynamic Generator(IEnumerable<Claim> claims);
        public string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        void SaveRefreshToken(string username, string refreshToken);
        string GetRefreshToken(string username);
        void DeleteRefreshToken(string username, string refreshToken);

    }
}
