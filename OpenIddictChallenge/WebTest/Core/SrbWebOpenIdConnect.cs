using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace SRPIntranet.IntegrationTest
{
    public class SrbWebOpenIdConnect
    {
        private readonly string _urlBase;
        private readonly string _scope;
        public TokenOppenIdConnect TokenOpenId { get; set; }

        public SrbWebOpenIdConnect(string urlBase, string scope = "openid email profile offline_access roles")
        {
            _urlBase = urlBase;
            _scope = scope;
        }

        public void Connect(string login, string pwd, string urlLogin)
        {
            using (var client = new HttpClient())
            {
                using (var request = new HttpRequestMessage(HttpMethod.Post, $"{_urlBase}{urlLogin}"))
                {
                    request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                        ["grant_type"] = "password",
                        ["username"] = login,
                        ["password"] = pwd,
                        ["scope"] = _scope
                    });

                    var response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead).Result;
                    response.EnsureSuccessStatusCode();


                    TokenOpenId = new TokenOppenIdConnect(response.Content.ReadAsStringAsync().Result);
                    if (TokenOpenId.HasError)
                    {
                        throw new InvalidOperationException("Error pour obtenir le token : " + TokenOpenId.Error);
                    }
                }
            }
        }

        public void Refresh(string login, string refrehToken)
        {
            using (var client = new HttpClient())
            {
                using (var request = new HttpRequestMessage(HttpMethod.Post, $"{_urlBase}{login}"))
                {
                    request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                        ["grant_type"] = "refresh_token",
                        ["refresh_token"] = refrehToken,
                        ["scope"] = _scope
                    });

                    var response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead).Result;
                    response.EnsureSuccessStatusCode();

                    var temp  = new TokenOppenIdConnect(response.Content.ReadAsStringAsync().Result);
                    if (temp.HasError)
                    {
                        throw new InvalidOperationException("Error pour obtenir le token : " + TokenOpenId.Error);
                    }
                    TokenOpenId.AccessToken = temp.AccessToken;
                }
            }
        }

        public string TestApi(string url, HttpMethod method, HttpContent content = null)
        {
            var requestUrl = (url.ToLower().StartsWith("http")) ? url : $"{_urlBase}{url}";
            using (var client = new HttpClient())
            {
                using (var request = new HttpRequestMessage(method, requestUrl))
                {
                    if(content != null) request.Content = content;
                    request.Headers.Authorization = new AuthenticationHeaderValue(TokenOpenId.TokenType, TokenOpenId.AccessToken);

                    var response = client.SendAsync(request, HttpCompletionOption.ResponseContentRead).Result;
                    response.EnsureSuccessStatusCode();

                    var result = response.Content.ReadAsStringAsync().Result;
                    return result;
                }
            }
        }

        public string GetClaim(string name)
        {
            return TokenOpenId.GetClaim(name);
        }
    }
}
