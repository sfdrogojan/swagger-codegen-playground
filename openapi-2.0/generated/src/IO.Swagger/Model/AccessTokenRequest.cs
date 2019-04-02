using System.Runtime.Serialization;

namespace IO.Swagger.Model
{
    [DataContract]
    public class AccessTokenRequest
    {
        [DataMember(Name = "client_id")]
        public string ClientId { get; set; }

        [DataMember(Name = "client_secret")]
        public string ClientSecret { get; set; }

        [DataMember(Name = "grant_type")]
        public string GrantType { get; set; }

        [DataMember(Name = "account_id")]
        public int AccountId { get; set; }

        public AccessTokenRequest(string clientId, string clientSecret, int accountId)
        {
            this.ClientId = clientId;
            this.ClientSecret = clientSecret;
            this.GrantType = "client_credentials";
            this.AccountId = accountId;
        }
    }
}
