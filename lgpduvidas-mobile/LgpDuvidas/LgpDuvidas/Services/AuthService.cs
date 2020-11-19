using LgpDuvidas.Data;
using LgpDuvidas.Interfaces;
using LgpDuvidas.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LgpDuvidas.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _client;

        public AuthService()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://lgpduvidas.azurewebsites.net/api/")
            };
        }
        public async Task<AuthModel> Register(AuthModel input)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");
                var response = await _client.PostAsync("register", content);

                response.EnsureSuccessStatusCode();
                await response.Content.ReadAsStringAsync();
            }
            catch (Exception err)
            {
            }
            return input;

        }
        public async Task<AuthModel> Login(AuthModel auth)
        {
            try
            {
                auth.user = auth.user.Trim();
                auth.pass = auth.pass.Trim();
                var content = new StringContent(JsonConvert.SerializeObject(auth), Encoding.UTF8, "application/json");
                var response = await _client.PostAsync("login", content);

                response.EnsureSuccessStatusCode();
                auth.Token = await response.Content.ReadAsStringAsync();
                auth.Token = auth.Token.Replace("\"", "");

                await SecureStorage.SetAsync("oauth_token", JsonConvert.SerializeObject(auth));
            }
            catch (Exception err)
            {
            }
            return auth;
        }
        public async Task<AuthModel> GetAuth()
        {
            AuthModel auth;
            try
            {
                auth = JsonConvert.DeserializeObject<AuthModel>(await SecureStorage.GetAsync("oauth_token")) ?? new AuthModel();
            }
            catch (Exception err)
            {
                auth = new AuthModel();
            }
            return auth;
        }
        public async Task<AuthModel> Refresh()
        {
            AuthModel auth;
            try
            {
                auth = JsonConvert.DeserializeObject<AuthModel>(await SecureStorage.GetAsync("oauth_token")) ?? new AuthModel();                
                auth = await this.Login(auth);
            }
            catch (Exception err)
            {
                auth = new AuthModel();
            }
            return auth;
        }
    }
}
