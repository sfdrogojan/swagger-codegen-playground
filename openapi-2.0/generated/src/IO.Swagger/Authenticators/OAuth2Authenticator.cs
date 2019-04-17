using System.ComponentModel.Design;
using System.Net;
using IO.Swagger.Client;
using RestSharp;
using System;

namespace IO.Swagger.Authenticators
{
    internal class OAuth2Authenticator : IAuthenticator
    {
        private readonly IAuthService authService;

        public OAuth2Authenticator(IAuthService authService)
        {
            this.authService = authService;
        }

        public void Authenticate(IRestClient client, IRestRequest request)
        {
            // workaround to support TLS 1.2 in .NET 4.5 (source: https://blogs.perficient.com/2016/04/28/tsl-1-2-and-net-support/)
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            var authResponse = authService.GetAuthorizationHeaderValue();

            request.AddHeader("Authorization", $"{authResponse.TokenType} {authResponse.AccessToken}");
        }
    }
}
