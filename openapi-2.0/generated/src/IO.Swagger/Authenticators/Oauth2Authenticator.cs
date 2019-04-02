﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using IO.Swagger.Client;
using IO.Swagger.Model;
using RestSharp;

namespace IO.Swagger.Authenticators
{
    class OAuth2Authenticator : IAuthenticator
    {
        private readonly Configuration configuration;

        public OAuth2Authenticator(Configuration configuration)
        {
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
            var authApiClient = new ApiClient(configuration.AuthenticationInstanceUrl) { Configuration = configuration };

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

            var accessTokenApiResponse = new ApiResponse<AccessTokenResponse>(
                (int)authRequestResponse.StatusCode,
                authRequestResponse.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (AccessTokenResponse)configuration.ApiClient.Deserialize(authRequestResponse, typeof(AccessTokenResponse)));

            return accessTokenApiResponse.Data;
        }
    }
}
