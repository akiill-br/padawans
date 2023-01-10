using ApiResource.Application.Services;
using domain.resource.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.resource.Services.Interfaces
{
    public interface IOAuthGitHubService
    {
        public Task<OAuthGitHubTokens> GetOAuthGitHubAsync(string code);
        public Task<(string, string)> GetEmailAndIdAsync(string accessToken);
        public Task<ResultService<dynamic>> GenerateTokenAsync(OAuthGitHubTokens oAuthGitHub);

    }
}
