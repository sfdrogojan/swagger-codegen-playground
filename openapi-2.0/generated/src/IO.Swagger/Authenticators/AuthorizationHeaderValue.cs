namespace IO.Swagger.Authenticators
{
    public class AuthorizationHeaderValue
    {
        public string TokenType { get; set; }

        public string AccessToken { get; set; }

        public AuthorizationHeaderValue(string accessToken, string tokenType)
        {
            this.AccessToken = accessToken;
            this.TokenType = tokenType;
        }
    }
}