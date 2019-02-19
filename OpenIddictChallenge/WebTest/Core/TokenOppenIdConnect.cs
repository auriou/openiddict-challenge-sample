using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace SRPIntranet.IntegrationTest
{
    public class TokenOppenIdConnect
    {
        public string AccessToken { get; set; }
        public string ExpiresIn { get; set; }
        public string IdToken { get; set; }
        public string RefreshToken { get; set; }
        public string TokenType { get; set; }
        public string Scope { get; set; }
        public string Error { get; set; }
        public bool HasError
        {
            get
            {
                return !string.IsNullOrEmpty(Error);
            }
        }
        public TokenOppenIdConnect(string contentJson)
        {
            var payload = JObject.Parse(contentJson);
            AccessToken = payload.ContainsKey("access_token") ? (string)payload["access_token"] : string.Empty;
            ExpiresIn = payload.ContainsKey("expires_in") ? (string)payload["expires_in"] : string.Empty;
            IdToken = payload.ContainsKey("id_token") ? (string)payload["id_token"] : string.Empty;
            RefreshToken = payload.ContainsKey("refresh_token") ? (string)payload["refresh_token"] : string.Empty;
            TokenType = payload.ContainsKey("token_type") ? (string)payload["token_type"] : string.Empty;
            Error = payload.ContainsKey("error") ? (string)payload["error"] : string.Empty;
        }

        public string GetClaim(string name)
        {
            var handler = new JwtSecurityTokenHandler();
            var tokenSecure = handler.ReadToken(IdToken) as JwtSecurityToken;
            return string.Join(",", tokenSecure.Claims.Where(p => p.Type == name).Select(p => p.Value));
        }

        //public string GetClaims()
        //{
        //    var handler = new JwtSecurityTokenHandler();
        //    var tokenSecure = handler.ReadToken(IdToken) as JwtSecurityToken;
        //    var dico = new Dictionary<string, List<string>>();
        //    tokenSecure.Claims.Select(p => p.Value);
        //}
    }
}
