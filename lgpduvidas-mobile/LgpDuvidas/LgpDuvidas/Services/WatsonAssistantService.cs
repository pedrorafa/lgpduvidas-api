using LgpDuvidas.Interfaces;
using LgpDuvidas.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LgpDuvidas.Services
{
    public class WatsonAssistantService: IWatsonAssistantService
    {
        private readonly HttpClient _client;

        public WatsonAssistantService()
        {
            _client = new HttpClient {
                BaseAddress = new Uri("https://lgpduvidas.azurewebsites.net/")
            };
        }

        public async Task<WatsonMessage> Send(WatsonMessage input)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");
                var response = await _client.PostAsync("message", content);

                response.EnsureSuccessStatusCode();

                return JsonConvert.DeserializeObject<WatsonMessage>(await response.Content.ReadAsStringAsync());
            }
            catch(Exception err)
            {
                return null;
            }
        }
    }
}
