using System;
using System.Collections.Generic;
using IO.Swagger.Client;
using IO.Swagger.Model;
using RestSharp;

namespace IO.Swagger.Authenticators
{
    public class AuthService : IAuthService
    {
        private readonly Configuration configuration;
        private readonly IApiClient apiClient;
        private readonly ICacheService cacheService;

        public AuthService(Configuration configuration, IApiClient apiClient, ICacheService cacheService)
        {
            this.apiClient = apiClient;
            this.cacheService = cacheService;
            this.configuration = configuration;
        }
        public AuthorizationHeaderValue GetAuthorizationHeaderValue()
        {
            var cachedValue = cacheService.Get(GetCacheKey(configuration));

            if (cachedValue == null)
            {
                apiClient.Configuration = configuration;

                var authApiClient = apiClient;

                var serializedAuthRequestBody =
                    authApiClient.Serialize(new AccessTokenRequest(configuration.ClientId,
                        configuration.ClientSecret, configuration.AccountId));

                IRestResponse authRequestResponse = (IRestResponse) authApiClient.CallApi("/v2/token",
                    Method.POST,
                    new List<KeyValuePair<string, string>>(),
                    serializedAuthRequestBody,
                    new Dictionary<string, string>(),
                    new Dictionary<string, string>(),
                    new Dictionary<string, FileParameter>(),
                    new Dictionary<string, string>(),
                    "application/json");

                var exceptionFactory = Configuration.DefaultExceptionFactory;
                if (exceptionFactory != null)
                {
                    Exception exception = exceptionFactory("GetAuthorizationHeaderValue", authRequestResponse);
                    if (exception != null) throw exception;
                }
                var response =
                    (AccessTokenResponse) configuration.ApiClient.Deserialize(authRequestResponse,
                        typeof(AccessTokenResponse));

                SetConfigParameters(response);
                cacheService.Add(GetCacheKey(configuration), response);

                return new AuthorizationHeaderValue(response.AccessToken, response.TokenType);
            }
            else
            {
                SetConfigParameters(cachedValue);
                return new AuthorizationHeaderValue(cachedValue.AccessToken, cachedValue.TokenType);
            }
        }

        public void SetConfigParameters(AccessTokenResponse response)
        {
            configuration.RestInstanceUrl = response.RestInstanceUrl;
            configuration.SoapInstanceUrl = response.SoapInstanceUrl;
            configuration.BasePath = response.RestInstanceUrl;
        }

        public string GetCacheKey(Configuration configuration)
        {
            return configuration.ClientId + "-" + configuration.AccountId;
        }
    }
}