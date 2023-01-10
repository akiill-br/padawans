using ApiResource.Application.Services;
using ApiResource.Domain.Authentication;
using ApiResource.Domain.Entities;
using ApiResource.Domain.Validations;
using ApiResource.Infra.Data.Repositories;
using app.resource.Services.Interfaces;
using domain.resource.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Web;

namespace app.resource.Services
{
    public class OAuthGitHubService : IOAuthGitHubService
    {

        private HttpClient client = new HttpClient();
        private readonly IUserRepository _userRepository;
        private readonly ITokenGenerator _tokenGenerator;

        public OAuthGitHubService(IUserRepository userRepository, ITokenGenerator tokenGenerator)
        {
            _userRepository = userRepository;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<(string, string)> GetEmailAndIdAsync(string accessToken)
        {
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            client.DefaultRequestHeaders.Add("User-Agent", "C# API");

            var response = await client.GetAsync($"https://api.github.com/user/emails");
            string query = string.Empty;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var receiveStream = await response.Content.ReadAsStreamAsync();
                StreamReader streamReader = new StreamReader(receiveStream);
                query = streamReader.ReadToEnd();
                streamReader.Close();
            }

            var valuePairs = JsonObject.Parse(query);
            var email = valuePairs[0]["email"].ToString();
            
            response = await client.GetAsync($"https://api.github.com/user");
            query = string.Empty;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var receiveStream = await response.Content.ReadAsStreamAsync();
                StreamReader streamReader = new StreamReader(receiveStream);
                query = streamReader.ReadToEnd();
                streamReader.Close();
            }

            valuePairs = JsonObject.Parse(query);
            var id = valuePairs["id"].ToString();

            //var oauthToken = JsonConvert.DeserializeObject<OauthToken>(json);

                
            DomainValidationException.When(email == null || id == null, "Email ou Id não são validos!");

            return (email.ToString(), id.ToString());

        }

        public async Task<OAuthGitHubTokens> GetOAuthGitHubAsync(string code)
        {
            var oauthGitHub = new OAuthGitHub();

            var client = new HttpClient();
            string query = string.Empty;

            var response = await client.GetAsync($"https://github.com/login/oauth/access_token?client_id=" +
            // CLIENT SECRET
                $"{oauthGitHub.ClientId}&redirect_uri={oauthGitHub.RedirectUri}&code={code}&client_secret=2af76f6953dc6f1dba4cda54c7ae5d8580e3ea9b");

            if(response.IsSuccessStatusCode)
            {
                var receiveStream = await response.Content.ReadAsStreamAsync();
                StreamReader streamReader= new StreamReader(receiveStream);
                query = streamReader.ReadToEnd();
                streamReader.Close();
            }

            var dict = HttpUtility.ParseQueryString(query);
            
            var json = JsonConvert.SerializeObject(
                                dict.AllKeys.ToDictionary(k => k, k => dict[k])
                       );

            var oauthGitHubTokens = JsonConvert.DeserializeObject<OAuthGitHubTokens>(json);

            return oauthGitHubTokens;

        }

        public async Task<ResultService<dynamic>> GenerateTokenAsync(OAuthGitHubTokens oAuthGitHub)
        {
            (string email, string id) = await GetEmailAndIdAsync(oAuthGitHub.access_token);
            var user = await _userRepository.GetUserByEmailAndPassowrd(email, id);
            
            if(user == null)
            {
                user = await _userRepository.CreateUserAsync(email, id);
            }

            return ResultService.Ok(_tokenGenerator.Generator(user));

        }

    }
}
