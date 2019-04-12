using System.ComponentModel.Design;
using System.Net;
using IO.Swagger.Client;
using RestSharp;

namespace IO.Swagger.Authenticators
{
    internal class OAuth2Authenticator : IAuthenticator
    {
        private readonly IAuthService authService;
        private Configuration configuration;

        public OAuth2Authenticator(IAuthService authService, Configuration configuration)
        {
            this.authService = authService;
            this.configuration = configuration;
        }

        public void Authenticate(IRestClient client, IRestRequest request)
        {
            // workaround to support TLS 1.2 in .NET 4.5 (source: https://blogs.perficient.com/2016/04/28/tsl-1-2-and-net-support/)
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            if (IsAccessTokenExpired() == true)
            {
                authService.Authenticate();
            } 

            request.AddHeader("Authorization", $"{configuration.TokenType} {configuration.AccessToken}");
        }

        public bool IsAccessTokenExpired()
        {
            var cacheKey = configuration.ClientId + "-" + configuration.AccountId;
            //var cacheValue  = dict.GetOrAdd(key)
            return false;
        }
    }
}
