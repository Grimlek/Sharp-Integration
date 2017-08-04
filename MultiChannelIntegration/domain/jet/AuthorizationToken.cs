using Newtonsoft.Json;
using System;


namespace Jet
{
    class AuthorizationToken
    {
        [JsonProperty(PropertyName = "user", NullValueHandling = NullValueHandling.Ignore)]
        public string User { get; set; }

        [JsonProperty(PropertyName = "pass", NullValueHandling = NullValueHandling.Ignore)]
        public string Pass { get; set; }

        [JsonProperty(PropertyName = "id_token", NullValueHandling = NullValueHandling.Ignore)]
        public string TokenId { get; set; }

        [JsonProperty(PropertyName = "token_type", NullValueHandling = NullValueHandling.Ignore)]
        public string TokenType { get; set; }

        [JsonProperty(PropertyName = "expires_on", NullValueHandling = NullValueHandling.Ignore)]
        public string TokenExpiration;


        public AuthorizationToken(string user, string pass)
        {
            this.User = user;
            this.Pass = pass;
        }


        public DateTime GetTokenExpiration()
        {
            return Convert.ToDateTime(this.TokenExpiration);
        }


        public void SetTokenExpiration(string tokenExpiration)
        {
            this.TokenExpiration = tokenExpiration;
        }
    }
}
