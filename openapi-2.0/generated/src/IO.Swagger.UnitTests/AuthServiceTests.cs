using System;
using System.Collections.Generic;
using System.Net;
using IO.Swagger.Authenticators;
using IO.Swagger.Client;
using IO.Swagger.Model;
using NSubstitute;
using NSubstitute.Core;
using NSubstitute.Core.Arguments;
using NSubstitute.ReceivedExtensions;
using NUnit.Framework;
using RestSharp;

namespace IO.Swagger.UnitTests
{
    [TestFixture]
    public class AuthServiceTests
    {
        [Test]
        public void GetAuthorizationHeaderValue_WhenValueIsNotPresentInCache_CallsTokenApi()
        {
            var configurationStub = new Configuration();
            var cacheServiceStub = Substitute.For<ICacheService>();
            var apiClientMock = Substitute.For<IApiClient>();
            var response = CreateAuthRequestResponse(HttpStatusCode.OK);
          
            apiClientMock.CallApi(
            Arg.Any<string>(),
                Arg.Any<Method>(),
                Arg.Any<List<KeyValuePair<string, string>>>(),
                Arg.Any<object>(),
                Arg.Any<Dictionary<string, string>>(),
                Arg.Any<Dictionary<string, string>>(),
                Arg.Any<Dictionary<string, FileParameter>>(),
                Arg.Any<Dictionary<string, string>>(),
                Arg.Any<string>()
            ).Returns(response);

            var authService = new AuthService(configurationStub, apiClientMock, cacheServiceStub);

            authService.GetAuthorizationHeaderValue();

            apiClientMock.Received().CallApi(
                Arg.Is("/v2/token"),
                Arg.Any<Method>(),
                Arg.Any<List<KeyValuePair<string, string>>>(),
                Arg.Any<object>(),
                Arg.Any<Dictionary<string, string>>(),
                Arg.Any<Dictionary<string, string>>(),
                Arg.Any<Dictionary<string, FileParameter>>(),
                Arg.Any<Dictionary<string, string>>(),
                Arg.Any<string>()
                );
        }

        [Test]
        public void GetAuthorizationHeaderValue_WhenValueIsNotPresentInCacheAndTokenApiFails_ThrowsException()
        {
            var configurationStub = new Configuration();
            var cacheServiceStub = Substitute.For<ICacheService>();
            var apiClientMock = Substitute.For<IApiClient>();
            var response = CreateAuthRequestResponse(HttpStatusCode.Unauthorized);

            apiClientMock.CallApi(
                Arg.Any<string>(),
                Arg.Any<Method>(),
                Arg.Any<List<KeyValuePair<string, string>>>(),
                Arg.Any<object>(),
                Arg.Any<Dictionary<string, string>>(),
                Arg.Any<Dictionary<string, string>>(),
                Arg.Any<Dictionary<string, FileParameter>>(),
                Arg.Any<Dictionary<string, string>>(),
                Arg.Any<string>()
            ).Returns(response);

            var authService = new AuthService(configurationStub, apiClientMock, cacheServiceStub);

            Assert.Throws<ApiException>(() => authService.GetAuthorizationHeaderValue());
        }

        [Test]
        public void SetConfigParameters_WhenValueIsNotPresentInCache_SetsConfigParameters()
        {
            var authRequestResponse = CreateAuthRequestResponse();
            var apiClientMock = CreateApiClient(authRequestResponse);
            var cacheServiceStub = CreateCacheService();
            var configurationStub = new Configuration();

            var authService = new AuthService(configurationStub, apiClientMock, cacheServiceStub);

            authService.GetAuthorizationHeaderValue();

            Assert.AreEqual("https://rest.com", configurationStub.RestInstanceUrl);
            Assert.AreEqual("https://soap.com", configurationStub.SoapInstanceUrl);
            Assert.AreEqual("https://rest.com", configurationStub.BasePath);
        }

        [Test]
        public void CacheServiceAdd_WhenValueIsNotPresentInCache_AddsAccessTokenResponseDateTimeTupleInCache()
        {
            var authRequestResponse = CreateAuthRequestResponse();
            var apiClientMock = CreateApiClient(authRequestResponse);
            var configurationStub = new Configuration();
            ICacheService cacheServiceMock = Substitute.For<ICacheService>();

            var authService = new AuthService(configurationStub, apiClientMock, cacheServiceMock);

            authService.GetAuthorizationHeaderValue();

            cacheServiceMock.Received().Add(Arg.Any<string>(), Arg.Any<AccessTokenResponse>());
        }

        [Test]
        public void GetAuthorizationHeaderValue_WhenValueIsNotPresentInCache_ReturnAuthorizationHeaderValue()
        {
            var authRequestResponse = CreateAuthRequestResponse();
            var apiClientMock = CreateApiClient(authRequestResponse);
            var configurationStub = new Configuration();
            ICacheService cacheServiceMock = Substitute.For<ICacheService>();

            var authService = new AuthService(configurationStub, apiClientMock, cacheServiceMock);

            var response = authService.GetAuthorizationHeaderValue();

            Assert.AreEqual(response.AccessToken, "access_token");
            Assert.AreEqual(response.TokenType, "token_type");
        }

        [Test]
        public void GetAuthorizationHeaderValue_WhenAuthenticationSucceeds_SetsConfigurationValues()
        {
            var authRequestResponse = CreateAuthRequestResponse();
            var apiClientMock = CreateApiClient(authRequestResponse);
            var configurationStub = new Configuration();
            ICacheService cacheServiceMock = Substitute.For<ICacheService>();

            var authService = new AuthService(configurationStub, apiClientMock, cacheServiceMock);

            authService.GetAuthorizationHeaderValue();

            Assert.AreEqual("https://rest.com", configurationStub.RestInstanceUrl);
            Assert.AreEqual("https://rest.com", configurationStub.BasePath);
            Assert.AreEqual("https://soap.com", configurationStub.SoapInstanceUrl);
        }

        [Test]
        public void GetAuthorizationHeaderValue_WhenAuthenticationFails_ThrowsException()
        {
            var authRequestResponse = CreateAuthRequestResponse(HttpStatusCode.Unauthorized);
            var apiClientMock = CreateApiClient(authRequestResponse);
            var configurationStub = new Configuration();
            ICacheService cacheServiceMock = Substitute.For<ICacheService>();

            var authService = new AuthService(configurationStub, apiClientMock, cacheServiceMock);

            IRestClient restClient = new RestClient("https://auth.com");
            IRestRequest request = new RestRequest();
            Assert.Throws<ApiException>(() => authService.GetAuthorizationHeaderValue());
        }
            
        [Test]   ///////////
        public void SetConfigParameters_WhenValueIsPresentInCache_SetsConfigParameters()
        {
            var authRequestResponse = CreateAuthRequestResponse();
            var apiClientMock = CreateApiClient(authRequestResponse);
            var configurationStub = new Configuration();

            var cacheServiceStub = CreateCacheService();
            AccessTokenResponse cacheServiceContent = cacheServiceStub.Get("someCacheKey");

            var authService = new AuthService(configurationStub, apiClientMock, cacheServiceStub);
            authService.SetConfigParameters(cacheServiceContent);

            Assert.AreEqual("https://rest.com", configurationStub.RestInstanceUrl);
            Assert.AreEqual("https://soap.com", configurationStub.SoapInstanceUrl);
            Assert.AreEqual("https://rest.com", configurationStub.BasePath);
        }

        [Test]   /////////// 
        public void GetAuthorizationHeaderValue_WhenValueIsPresentInCache_ReturnAuthorizationHeaderValue()
        {
            var authRequestResponse = CreateAuthRequestResponse();
            var apiClientMock = CreateApiClient(authRequestResponse);
            var configurationStub = new Configuration();
            var cacheServiceStub = CreateCacheService();

            var authService = new AuthService(configurationStub, apiClientMock, cacheServiceStub);

            var response = authService.GetAuthorizationHeaderValue();

            Assert.AreEqual(response.AccessToken, "access_token");
            Assert.AreEqual(response.TokenType, "token_type");
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

        private IAuthService CreateAuthService()
        {
            IAuthService authService = Substitute.For<IAuthService>();

            var accessToken = "access_token";
            var tokenType = "token_type";

            authService.GetAuthorizationHeaderValue().Returns(
                new AuthorizationHeaderValue(accessToken, tokenType)

            );

            return authService;
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
    }
}