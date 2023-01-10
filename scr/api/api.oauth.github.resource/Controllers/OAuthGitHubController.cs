using ApiResource.Application.Services.Interfaces;
using app.resource.Services.Interfaces;
using domain.resource.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Net;
using System.Web;


namespace api.oauth.github.resource.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OAuthGitHubController : ControllerBase
    {
        private readonly ILogger<OAuthGitHubController> _logger;
        private readonly IOAuthGitHubService _gitHubService;
        private readonly IUserService _userService;

        public OAuthGitHubController(ILogger<OAuthGitHubController> logger, IOAuthGitHubService gitHubService, IUserService userService)
        {
            _logger = logger;
            _gitHubService = gitHubService;
            _userService = userService;
        }

        [HttpGet]
        [Route("/api/OAuth/GitHub")]
        public async Task<ActionResult> oauthGithub(string code = "")
        {
            var oauthConfig = new OAuthGitHub();

            if (string.IsNullOrEmpty(code))
            {
                return Redirect($"https://github.com/login/oauth/authorize?client_id=" +
                    $"{oauthConfig.ClientId}&redirect_uri={oauthConfig.RedirectUri}&scope={oauthConfig.Scope}&response_type={oauthConfig.ResponseType}");
            }
            
            var oauthGitHub = await _gitHubService.GetOAuthGitHubAsync(code);

            var result = await _gitHubService.GenerateTokenAsync(oauthGitHub);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);

        }


    }
}