using DreamlerPhone.Models;
using DreamlerPhone.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DreamlerPhone
{
    public class Com
    {
        private HttpClient _httpClient;
        private HttpClientHandler _hcHandler;

        private static string _testEnvAddr = "https://dreamlerstaging.azurewebsites.net";
        private static Uri TestEnvUri = new Uri(_testEnvAddr);

        private const string LoginUrl = "api/User/Login";
        private const string MediaFormat = "application/vnd.drcl+json";

        public DreamUser User { get; set; }

        public Com() {
            _hcHandler = new HttpClientHandler() { Proxy = new Proxy( "http://10.71.34.1:8888" ) };
            _httpClient = new HttpClient(_hcHandler) { BaseAddress = TestEnvUri };
            
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add( "User-Agent", "drcl/1.9 (win;)" ); //( new ProductInfoHeaderValue( new ProductHeaderValue( "drcl", "1.9" ) ) );
            _httpClient.DefaultRequestHeaders.Host = "dreamlerstaging.azurewebsites.net";
            //when running local Host sohuld be set to "web.local"
        }

        public async Task<DreamUser> Login (string email, string password){
            try {
                var loginModel = new LoginVM { UsernameText = email, PasswordText = password };
                var response = await Post(LoginUrl, loginModel);
                if ( response.IsSuccessStatusCode ) {
                    User = JsonConvert.DeserializeObject<DreamUser>( await response.Content.ReadAsStringAsync() );
                    var headers = response.Headers.ToList();
                    var id = headers.Where(h => h.Key == "DreamlerIdentity").Select(t => t.Value.FirstOrDefault()).FirstOrDefault();
                    if ( id == null ) return null;
                    User.DreamlerIdentity = id;
                    _httpClient.DefaultRequestHeaders.Add( "DreamlerIdentity", id );
                    return User;
                }
                response.Dispose();
                return null;
            } catch (HttpRequestException httpRequestEx) {
                throw;
            } catch (Exception ex) {
                throw;
            }
        }

        private Task<HttpResponseMessage> Post( string url, object jsonObj ) {
            return _httpClient.PostAsync( url, new StringContent( JsonConvert.SerializeObject( jsonObj ), Encoding.UTF8, MediaFormat ) );
        }
    }
}