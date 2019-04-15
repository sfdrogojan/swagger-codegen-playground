using System;
using System.Runtime.Serialization;

namespace IO.Swagger.Model
{
    public class CachedAccessTokenResponse
    {
        public string AccessToken { get; set; }

        public DateTime ExpiresAt { get; set; }

        public string RestInstanceUrl { get; set; }

        public string SoapInstanceUrl { get; set; }

        public string TokenType { get; set; }

        public AccessTokenResponse ToAccessTokenResponse()
        {
            return new AccessTokenResponse()
            {
                AccessToken = this.AccessToken,
                RestInstanceUrl = this.RestInstanceUrl,
                SoapInstanceUrl = this.SoapInstanceUrl,
                TokenType = this.TokenType
            };
        }
    }
}