/* 
 * Marketing Cloud REST API
 *
 * Marketing Cloud's REST API is our newest API. It supports multi-channel use cases, is much more lightweight and easy to use than our SOAP API, and is getting more comprehensive with every release.
 *
 * OpenAPI spec version: 1.0.0
 * Contact: mc_sdk@salesforce.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System.Net;
using RestSharp;

namespace IO.Swagger.Authentication
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
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            var authorizationToken = authService.GetAuthorizationToken();

            request.AddHeader("Authorization", $"{authorizationToken.Type} {authorizationToken.Value}");
        }
    }
}
