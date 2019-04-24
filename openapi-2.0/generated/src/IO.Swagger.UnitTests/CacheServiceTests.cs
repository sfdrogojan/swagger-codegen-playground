using System;
using System.Collections.Concurrent;
using IO.Swagger.Authentication;
using IO.Swagger.Model;
using NUnit.Framework;

namespace IO.Swagger.UnitTests
{
    [TestFixture]
    public class CacheServiceTests
    {
        [Test]
        public void Get_WhenCacheIsNotExpired_ReturnsCachedValue()
        {
            var currentTime = new DateTime(2000, 1, 1);
            var datetimeProviderStub = new SettableDateTimeProvider(currentTime);
            var accessTokenResponse = CreateAccessTokenResponse();

            var cacheService = new CacheService(datetimeProviderStub);
            var cacheKey = "cacheKey";
            cacheService.AddOrUpdate(cacheKey, accessTokenResponse);

            datetimeProviderStub.Now = currentTime.AddMinutes(10);
            var response = cacheService.Get(cacheKey);

            Assert.AreEqual("access_token", response.AccessToken);
            Assert.AreEqual("token_type", response.TokenType);
            Assert.AreEqual(1000, response.ExpiresIn);
            Assert.AreEqual("https://rest.com", response.RestInstanceUrl);
            Assert.AreEqual("https://soap.com", response.SoapInstanceUrl);
        }

        [Test]
        public void Get_WhenCacheIsExpired_ReturnsNull()
        {
            var currentTime = new DateTime(2000, 1, 1);
            var dateTimeProvider = new SettableDateTimeProvider(currentTime);
            var cacheService = new CacheService(dateTimeProvider);
            var accessTokenResponse = CreateAccessTokenResponse();

            var cacheKey = "cacheKey";
            cacheService.AddOrUpdate(cacheKey, accessTokenResponse);

            var newCurrentTime = currentTime.AddMinutes(20);
            dateTimeProvider.Now = newCurrentTime;

            var response = cacheService.Get(cacheKey);

            Assert.AreEqual(null, response);
        }

        [Test]
        public void AddOrUpdate_WhenCalledAndKeyIsNotInCache_AddsValueInCache()
        {
            var currentTime = new DateTime(2000, 1, 1);
            var dateTimeProvider = new SettableDateTimeProvider(currentTime);
            var cacheService = new CacheService(dateTimeProvider);
            var accessTokenResponse = CreateAccessTokenResponse();

            var cacheKey = "cacheKey";
            cacheService.AddOrUpdate(cacheKey, accessTokenResponse);

            var cachedValue = cacheService.Get(cacheKey);
            Assert.AreSame(cachedValue, accessTokenResponse);
        }

        [Test]
        public void AddOrUpdate_WhenCalledTwoTimesForTheSameKey_OverwritesValueInCache()
        {
            var currentTime = new DateTime(2000, 1, 1);
            var dateTimeProvider = new SettableDateTimeProvider(currentTime);
            var cacheService = new CacheService(dateTimeProvider);
            var accessTokenResponse = CreateAccessTokenResponse();

            var cacheKey = "cacheKey";
            cacheService.AddOrUpdate(cacheKey, accessTokenResponse);

            var newAccessTokenResponse = CreateAccessTokenResponse();
            cacheService.AddOrUpdate(cacheKey, newAccessTokenResponse);

            var cachedValue = cacheService.Get(cacheKey);
            Assert.AreSame(cachedValue, newAccessTokenResponse);
        }

        [TestCase(299, false)]
        [TestCase(300, false)]
        [TestCase(301, true)]
        public void Get_WhenCalledForACachedValue_ReturnsBasedOnInvalidCacheWindow(int windowInSeconds, bool isValid)
        {
            var currentTime = new DateTime(2000, 1, 1);
            var dateTimeProvider = new SettableDateTimeProvider(currentTime);
            var cacheService = new CacheService(dateTimeProvider);
            var accessTokenResponse = CreateAccessTokenResponse();

            var cacheKey = "cacheKey";
            cacheService.AddOrUpdate(cacheKey, accessTokenResponse);

            dateTimeProvider.Now = currentTime.AddSeconds(accessTokenResponse.ExpiresIn).Subtract(TimeSpan.FromSeconds(windowInSeconds));
            var cachedValue = cacheService.Get(cacheKey);
            var expectedIsValid = cachedValue != null;
            Assert.AreEqual(expectedIsValid, isValid);
        }

        [TearDown]
        public void CleanUp()
        {
            CacheService.cache = new ConcurrentDictionary<string, Tuple<AccessTokenResponse, DateTime>>();
        }

        private AccessTokenResponse CreateAccessTokenResponse()
        {
            var accessTokenResponse = new AccessTokenResponse
            {
                AccessToken = "access_token",
                TokenType = "token_type",
                ExpiresIn = 1000,
                RestInstanceUrl = "https://rest.com",
                SoapInstanceUrl = "https://soap.com"
            };
            return accessTokenResponse;
        }
    }
}