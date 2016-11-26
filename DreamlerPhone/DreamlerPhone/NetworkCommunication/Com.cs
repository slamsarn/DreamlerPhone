using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DreamlerPhone.Models;
//using DreamlerPhone.ViewModels;

namespace DreamlerPhone {
    public class Com {
        private HttpClient      _httpClient;
        private HttpClientHandler _hcHandler;

        private static string   _testEnvAddr    = "https://dreamlerstaging.azurewebsites.net";
        private static Uri      TestEnvUri      = new Uri(_testEnvAddr);

        private const string    LoginUrl        = "api/User/Login";
        private const string    MediaFormat     = "application/vnd.drcl+json";
        private const string    DreamBoardsUrl  = "/api/DreamBoard/";

        public DreamUser User { get; set; }

        public Com() {
            _hcHandler  = new HttpClientHandler() { Proxy = new Proxy( "http://10.71.34.1:8888" ) };
            _httpClient = new HttpClient( _hcHandler ) { BaseAddress = TestEnvUri };

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add( "User-Agent", "drcl/1.9 (win;)" );
            _httpClient.DefaultRequestHeaders.Host = "dreamlerstaging.azurewebsites.net";
        }

        public async Task<DreamUser> Login( string email, string password ) {
            try {
                var loginModel = new LoginModel { Email = email, Password = password };
                var response = await Post(LoginUrl, loginModel);
                if ( response.IsSuccessStatusCode ) {
                    var headers = response.Headers.ToList();
                    var id = headers.Where(h => h.Key == "DreamlerIdentity").Select(t => t.Value.FirstOrDefault()).FirstOrDefault();

                    if ( id == null ) return null;

                    User = JsonConvert.DeserializeObject<DreamUser>( await response.Content.ReadAsStringAsync() );
                    User.DreamlerIdentity = id;
                    _httpClient.DefaultRequestHeaders.Add( "DreamlerIdentity", id );

                    return User;
                }
                response.Dispose();
                return null;
            } catch ( HttpRequestException httpRequestEx ) {
                throw;
            } catch ( Exception ex ) {
                throw;
                //ex.Message.ToString();
                //ex.ToString();
            }
        }
        private Task<HttpResponseMessage> Post( string url, object jsonObj ) {
            return _httpClient.PostAsync( url, new StringContent( JsonConvert.SerializeObject( jsonObj ), Encoding.UTF8, MediaFormat ) );
        }
        public async Task<IEnumerable<DreamBoard>> GetMyDreamBoards() {
            var dreamBoardList = JsonConvert.DeserializeObject<IEnumerable<DreamBoard>>(await GetAsyncString(DreamBoardsUrl));
            return dreamBoardList;
        }
        private async Task<string> GetAsyncString( string url ) {
            var responseMessage = await GetAsync(url);
            if ( responseMessage.IsSuccessStatusCode ) {
                return ( await responseMessage.Content.ReadAsStringAsync() );
            }
            return null;
        }
        private Task<HttpResponseMessage> GetAsync( string url ) {
            return _httpClient.GetAsync( url );
        }
        private async Task<string> PostWithReturn( string url, object jsonObject ) {
            var responseMessage = await Post(url, jsonObject);
            if ( responseMessage.IsSuccessStatusCode ) {
                return ( await responseMessage.Content.ReadAsStringAsync() );
            }
            return null;
        }
        public async Task<HttpResponseMessage> GetDreamBoard( long dbId ) {
            return await GetAsync( DreamBoardsUrl + $"History/{dbId}" );
        }
        public async Task<Stream> GetImage( string imagePath ) {
            var responseMessage = await GetAsync(imagePath);
            if ( responseMessage.IsSuccessStatusCode ) {
                return await responseMessage.Content.ReadAsStreamAsync();
            }
            return null;
        }
    }
}