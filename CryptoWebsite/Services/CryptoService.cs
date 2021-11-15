using CryptoWebsite.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;


namespace CryptoWebsite.Services
{
    public class CryptoService
    {
        private readonly HttpClient _httpClient;
        private readonly CryptoOptions _cryptoOptions;

        public CryptoService(HttpClient httpClient, IOptions<CryptoOptions> cryptoConfiguration)
        {
            _httpClient = httpClient;
            _cryptoOptions = cryptoConfiguration.Value;
            _httpClient.BaseAddress = new(_cryptoOptions.Endpoint);
            _httpClient.DefaultRequestHeaders.Add("X-CoinAPI-Key", _cryptoOptions.ApiKey);
        }

        // Get list of exchanges
        public async ValueTask<CryptoExchange[]> GetCryptoExchangeAsync()
        {
            CryptoExchange[]? data = null;
            try
            {
                var response = await _httpClient.GetAsync("/v1/exchanges");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                data = JsonConvert.DeserializeObject<CryptoExchange[]>(content);
            }
            catch (Exception e)
            {
                Console.WriteLine("\t\tERROR {0}", e.Message);
            }
            return data!;
        }

    }
}
