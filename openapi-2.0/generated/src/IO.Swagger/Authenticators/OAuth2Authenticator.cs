﻿using System;
using System.Collections.Generic;
using System.Net;
using IO.Swagger.Client;
using IO.Swagger.Model;
using RestSharp;

namespace IO.Swagger.Authenticators
{
    internal class OAuth2Authenticator : IAuthenticator
    {
        private readonly Configuration configuration;
        private readonly IApiClient apiClient;

        public OAuth2Authenticator(Configuration configuration, IApiClient apiClient)
        {
            this.apiClient = apiClient;
            this.configuration = configuration;
        }

        public void Authenticate(IRestClient client, IRestRequest request)
        {
            // workaround to support TLS 1.2 in .NET 4.5 (source: https://blogs.perficient.com/2016/04/28/tsl-1-2-and-net-support/)
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            var accessTokenResponse = this.Authenticate();

            configuration.RestInstanceUrl = accessTokenResponse.RestInstanceUrl;
            configuration.SoapInstanceUrl = accessTokenResponse.SoapInstanceUrl;
            configuration.BasePath = accessTokenResponse.RestInstanceUrl;

            request.AddHeader("Authorization", $"{accessTokenResponse.TokenType} {accessTokenResponse.AccessToken}");
        }

        private AccessTokenResponse Authenticate()
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
            
            return (AccessTokenResponse)configuration.ApiClient.Deserialize(authRequestResponse, typeof(AccessTokenResponse));
        }
    }
}