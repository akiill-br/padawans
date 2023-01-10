using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace domain.resource.Entities
{
    public class OAuthGitHub
    {
        public string ClientId { get; set; }
        public string Scope { get; set; }
        public string RedirectUri { get; set; }
        public string ResponseType { get; set; }

        public OAuthGitHub()
        {
            JToken jAppSettings = JToken.Parse(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, ".env.json")));
            ClientId = jAppSettings["oauth"]["client_id"].ToString();
            Scope = jAppSettings["oauth"]["scope"].ToString();
            RedirectUri = jAppSettings["oauth"]["redirect_uri"].ToString();
            ResponseType = jAppSettings["oauth"]["response_type"].ToString();
        }
    }
}
