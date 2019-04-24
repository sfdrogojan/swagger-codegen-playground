namespace IO.Swagger.Authentication
{
    public class AuthorizationToken
    {
        public string Type { get; set; }

        public string Value { get; set; }

        public AuthorizationToken(string value, string type)
        {
            this.Value = value;
            this.Type = type;
        }
    }
}