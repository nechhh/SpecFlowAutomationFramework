using OpenQA.Selenium.DevTools.V118.Storage;
using RestSharp;
using RestSharp.Authenticators;
using SpecFlowAutomationFramework.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowAutomationFramework.Helpers.API

    //this class will genarate the token
{
    public class APIAuthenticator : AuthenticatorBase

    {
        readonly string baseUrl;
        readonly string clientId;
        readonly string clientSecret;

        public APIAuthenticator() : base("")
        {

        }


        protected override async ValueTask<Parameter> GetAuthenticationParameter(string accessToken)
        {
            var token =string.IsNullOrEmpty(Token) ? await GetToken() : Token;

            return new HeaderParameter(KnownHeaders.Authorization, token);
        }
        
        //this method will get the token
        private async Task<string> GetToken()
        {
            var options = new RestClientOptions(baseUrl);
            var client = new RestClient(options)
            {
                Authenticator = new HttpBasicAuthenticator(clientId, clientSecret),
            };

            var request = new RestRequest("oauth2/token")
                .AddParameter("grant_type", "client_credenatials");
            var response = await client.PostAsync<TokenResponse>(request);

            return $"{response.TokenType} {response.AccessToken}";

        }
    }
}
