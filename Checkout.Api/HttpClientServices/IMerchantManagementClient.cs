using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace Checkout.Api.HttpClientServices
{
    public interface IMerchantManagementClient
    {
        Task<IEnumerable<WeatherForecast>?> GetWeatherForecast();
    }

    public class MerchantManagementClient : IMerchantManagementClient
    {
        private readonly HttpClient _httpClient;

        public MerchantManagementClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<WeatherForecast>?> GetWeatherForecast()
        {
            var response = await _httpClient.GetAsync("WeatherForecast");

            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return System.Text.Json.JsonSerializer.Deserialize<WeatherForecast[]>(responseContent);
        }
    }
}
