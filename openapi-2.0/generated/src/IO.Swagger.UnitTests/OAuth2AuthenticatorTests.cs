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
            var authRequestResponse = CreateAuthRequestResponse();

            var apiClient = CreateApiClient(authRequestResponse);

            var configuration = new Configuration();

            var cacheService = CreateCacheService();

            IAuthenticator oAuth2Authenticator = new Authenticators.OAuth2Authenticator(new AuthService(configuration, apiClient, cacheService));

            IRestClient restClient = new RestClient("https://auth.com");
            IRestRequest request = new RestRequest();
            oAuth2Authenticator.Authenticate(restClient, request);

            var authorizationHeader =
                request.Parameters.First(p => p.Type == ParameterType.HttpHeader && p.Name == "Authorization");

            Assert.AreEqual("token_type access_token", authorizationHeader.Value);
        }

        [Test]
        public void Authenticate_WhenAuthenticationSucceeds_SetsConfigurationValues()
        {
            var authRequestResponse = CreateAuthRequestResponse();

            var apiClient = CreateApiClient(authRequestResponse);

            var configuration = new Configuration();

            var cacheService = CreateCacheService();

            IAuthenticator oAuth2Authenticator = new Authenticators.OAuth2Authenticator(new AuthService(configuration, apiClient, cacheService));

            IRestClient restClient = new RestClient("https://auth.com");
            IRestRequest request = new RestRequest();
            oAuth2Authenticator.Authenticate(restClient, request);

            Assert.AreEqual("https://rest.com", configuration.RestInstanceUrl);
            Assert.AreEqual("https://rest.com", configuration.BasePath);
            Assert.AreEqual("https://soap.com", configuration.SoapInstanceUrl);
        }

        [Test]
        public void Authenticate_WhenAuthenticationFails_ThrowsException()
        {
            var authRequestResponse = CreateAuthRequestResponse(HttpStatusCode.Unauthorized);

            var apiClient = CreateApiClient(authRequestResponse);

            var configuration = new Configuration();

            ICacheService cacheService = Substitute.For<ICacheService>();

            IAuthenticator oAuth2Authenticator = new Authenticators.OAuth2Authenticator(new AuthService(configuration, apiClient, cacheService));

            IRestClient restClient = new RestClient("https://auth.com");
            IRestRequest request = new RestRequest();
            Assert.Throws<ApiException>(() => oAuth2Authenticator.Authenticate(restClient, request));
        }

        private ICacheService CreateCacheService()
        {
            ICacheService cacheService = Substitute.For<ICacheService>();

            cacheService.Get(Arg.Any<string>()).Returns(new AccessTokenResponse()
            {
                AccessToken = "access_token",
                TokenType = "token_type",
                RestInstanceUrl = "https://rest.com",
                SoapInstanceUrl = "https://soap.com",
                ExpiresIn = 1000
            });

            return cacheService;
        }

        private IApiClient CreateApiClient(IRestResponse authRequestResponse)
        {
            IApiClient apiClient = Substitute.For<IApiClient>();
            apiClient
                .CallApi(
                    Arg.Any<string>(),
                    Arg.Any<Method>(),
                    Arg.Any<List<KeyValuePair<string, string>>>(),
                    Arg.Any<object>(),
                    Arg.Any<Dictionary<string, string>>(),
                    Arg.Any<Dictionary<string, string>>(),
                    Arg.Any<Dictionary<string, FileParameter>>(),
                    Arg.Any<Dictionary<string, string>>(),
                    Arg.Any<string>()
                ).Returns(authRequestResponse);
            return apiClient;
        }

        private IRestResponse CreateAuthRequestResponse(HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            IRestResponse authRequestResponse = Substitute.For<IRestResponse>();
            authRequestResponse.Content.Returns(@"{ 
                'access_token': 'access_token', 
                'token_type': 'token_type',
                'expires_in': 1000,
                'rest_instance_url':'https://rest.com',
                'soap_instance_url':'https://soap.com'
            }");
            authRequestResponse.StatusCode.Returns(httpStatusCode);
            return authRequestResponse;
        }
    }
}
