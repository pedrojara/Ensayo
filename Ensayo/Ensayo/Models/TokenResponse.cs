namespace Ensayo.Models
{
    using System;
    using Newtonsoft.Json;

    class TokenResponse
    {
        #region Properties
        [JsonProperty(PropertyName = "acces_token")]
        public string AccesToken { get; set; }

        [JsonProperty(PropertyName = "token_type")]
        public string Tokentype { get; set; }

        [JsonProperty(PropertyName = "expires_in")]
        public int Expires_in { get; set; }

        [JsonProperty(PropertyName = "userName")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = ".issued")]
        public DateTime Issued { get; set; }

        [JsonProperty(PropertyName = ".expires")]
        public DateTime Expires { get; set; }

        [JsonProperty(PropertyName = "error_description")]
        public string Error_description { get; set; }
        #endregion
    }
}
