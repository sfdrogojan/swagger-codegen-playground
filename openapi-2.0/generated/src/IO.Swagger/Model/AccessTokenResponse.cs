﻿using System.Runtime.Serialization;

namespace IO.Swagger.Model
{
    [DataContract]
    public class AccessTokenResponse
    {
        [DataMember(Name = "access_token")]
        public string AccessToken { get; set; }

        [DataMember(Name = "expires_in")]
        public int ExpiresIn { get; set; }

        [DataMember(Name = "rest_instance_url")]
        public string RestInstanceUrl { get; set; }

        [DataMember(Name = "soap_instance_url")]
        public string SoapInstanceUrl { get; set; }

        [DataMember(Name = "token_type")]
        public string TokenType { get; set; }
    }
}
