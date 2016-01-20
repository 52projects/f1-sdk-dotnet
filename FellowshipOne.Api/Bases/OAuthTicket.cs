using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FellowshipOne.Api {
    [JsonObject()]
    public class OAuthTicket {
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string Scope { get; set; }
        public string TokenType { get; set; }
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        public string AccessTokenSecret { get; set; }
        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }
        [JsonProperty("expires_in")]
        public decimal ExpiresIn { get; set; }
        public int PersonID { get; set; }
    }
}
