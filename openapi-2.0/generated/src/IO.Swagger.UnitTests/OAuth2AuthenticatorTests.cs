using System.Collections.Generic;
using System.Linq;
using System.Net;
using IO.Swagger.Authenticators;
using IO.Swagger.Client;
using IO.Swagger.Model;
using NSubstitute;
using NUnit.Framework;
using RestSharp;

namespace IO.Swagger.UnitTests
{
    [TestFixture]
    public class OAuth2AuthenticatorTests
    {
        [Test]
        public void Authenticate_WhenAuthenticationSucceeds_SetsAuthenticationHeader()
        {
            IAuthService authServiceStub = Substitute.For<IAuthService>();
            authServiceStub.GetAuthorizationHeaderValue()
                .Returns(new AuthorizationHeaderValue("access_token", "token_type"));

            IAuthenticator oAuth2Authenticator =
                new Authenticators.OAuth2Authenticator(authServiceStub);

            IRestClient restClient = new RestClient("https://auth.com");
            IRestRequest request = new RestRequest();
            oAuth2Authenticator.Authenticate(restClient, request);

            var authorizationHeader =
                request.Parameters.First(p => p.Type == ParameterType.HttpHeader && p.Name == "Authorization");

            Assert.AreEqual("token_type access_token", authorizationHeader.Value);
        }
    }
}
