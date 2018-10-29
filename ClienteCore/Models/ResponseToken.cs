using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteCore.Models
{
    public class ResponseToken
    {
        [JsonProperty("AccessToken")]
        public string AccessToken { get; set; }

        //[JsonProperty("TokenType")]
        //public string TokenType { get; set; }

        [JsonProperty("Expire")]
        public DateTime Expire { get; set; }

        //[JsonProperty("RefreshToken")]
        //public string RefreshToken { get; set; }
    }
}