using System;
using System.Collections.Generic;
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
    public class CacheServiceTests
    {
        [Test]
        public void Get_WhenCacheIsSetAndNotExpired_ReturnsAccessTokenResponse()
        {
            IDateTimeProvider datetimeProvider = new SettableDateTimeProvider(new DateTime(2019, 1, 1));
            var authRequestResponse = CreateAuthRequestResponse();

            CacheService cacheService = new CacheService(datetimeProvider);
            var accessTokenResponse = new AccessTokenResponse()
            {
                AccessToken = "access_token",
                TokenType = "token_type", 
                ExpiresIn = 1000,
                RestInstanceUrl = "https://rest.com",
                SoapInstanceUrl = "https://soap.com"
            };

            cacheService.Add("cacheKey", accessTokenResponse);
            cacheService.dateTimeProvider.Now.AddMinutes(5);

            var response = cacheService.Get("cacheKey");

            Assert.AreEqual("access_token", response.AccessToken);
            Assert.AreEqual("token_type", response.TokenType);
            Assert.AreEqual(1000, response.ExpiresIn);
            Assert.AreEqual("https://rest.com", response.RestInstanceUrl);
            Assert.AreEqual("https://soap.com", response.SoapInstanceUrl);
        }

        [Test]
        public void Get_WhenCacheIsSetAndNotExpired_ReturnsNull()
        {
            IDateTimeProvider datetimeProvider = new SettableDateTimeProvider(new DateTime(2019, 1, 1));
            var authRequestResponse = CreateAuthRequestResponse();

            CacheService cacheService = new CacheService(datetimeProvider);
            var accessTokenResponse = new AccessTokenResponse()
            {
                AccessToken = "access_token",
                TokenType = "token_type",
                ExpiresIn = 1000,
                RestInstanceUrl = "https://rest.com",
                SoapInstanceUrl = "https://soap.com"
            };

            cacheService.Add("cacheKey", accessTokenResponse);
            // to create time lapse  

            var response = cacheService.Get("cacheKey");

            Assert.AreEqual(null, response);
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