using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.resource.Entities
{
    public class OAuthGitHubTokens
    {
        public string access_token { get; set; }
        public string scope { get; set; }
        public string token_type { get; set; }
    }
}
