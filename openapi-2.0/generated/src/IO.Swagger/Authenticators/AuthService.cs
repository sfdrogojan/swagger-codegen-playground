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

        public AuthService(Configuration configuration, IApiClient apiClient)
        {
            this.apiClient = apiClient;
            this.configuration = configuration;
        }
        public void Authenticate()
        {
            apiClient.Configuration = configuration;

            var authApiClient = apiClient;

            var serializedAuthRequestBody =
                authApiClient.Serialize(new AccessTokenRequest(configuration.ClientId,
                    configuration.ClientSecret, configuration.AccountId));

            IRestResponse authRequestResponse = (IRestResponse)authApiClient.CallApi("/v2/token",
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
                Exception exception = exceptionFactory("Authenticate", authRequestResponse);
                if (exception != null) throw exception;
            }

            var response = (AccessTokenResponse)configuration.ApiClient.Deserialize(authRequestResponse, typeof(AccessTokenResponse));

            SetConfigParameters(response);
        }
        public void SetConfigParameters(AccessTokenResponse response)
        {
            configuration.RestInstanceUrl = response.RestInstanceUrl;
            configuration.SoapInstanceUrl = response.SoapInstanceUrl;
            configuration.BasePath = response.RestInstanceUrl;
            configuration.TokenType = response.TokenType;
            configuration.AccessToken = response.AccessToken;
        }
    }

/*

    public class CachingOAuth2Authenticator : IAuthenticator
    {
        private readonly IAuthenticator decoratedAuthenticator;

        public CachingOAuth2Authenticator(IAuthenticator decoratedAuthenticator)
        {
            this.decoratedAuthenticator = decoratedAuthenticator;
        }

        public void Authenticate(IRestClient client, IRestRequest request)
        {
            // check cache. daca cache-ul e valid, nu mai fa apel la v2/token
            // pass through to the decorated component since it has all the valid information it needs (Configuration.AccessToken)

            // daca nu exista in cache, sau e expirat
            // call the Authenticate method, cache the result, set Configuration properties with new cvalues si apoi apel la componenta decorata

            decoratedAuthenticator.Authenticate(client, request);
        }
    }*/
}