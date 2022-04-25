using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace Checkout.Api.HttpClientServices
{
    public abstract class BaseHttpClient
    {
        protected HttpClient HttpClient;

        protected BaseHttpClient(HttpClient client)
        {
               HttpClient  = client;
        }

        public async Task<T> Get<T>(string url, CancellationToken cancellationToken = default) where T : class
        {
            var response = await HttpClient.GetAsync($"{HttpClient.BaseAddress}{url}", cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            return Deserialize<T>(content);
        }

        public async Task<TResponse> Post<TRequest, TResponse>(string url, TRequest data, CancellationToken cancellationToken = default)
        {
            var response = await HttpClient.PostAsJsonAsync($"{HttpClient.BaseAddress}{url}", data, cancellationToken);
            var content = await response.Content.ReadAsStringAsync();
            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException e)
            {
                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    var validation = Deserialize<ValidationFailure[]>(content);
                    throw new Checkout.Api.Exception.ValidationException(validation);
                }

                throw;
            }

            return Deserialize<TResponse>(content);
        }

        public async Task Post<TRequest>(string url, TRequest data, CancellationToken cancellationToken = default)
        {
            var response = await HttpClient.PostAsJsonAsync($"{HttpClient.BaseAddress}{url}", data, cancellationToken);
            response.EnsureSuccessStatusCode();
        }

        protected T Deserialize<T>(string content)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            return JsonSerializer.Deserialize<T>(content, options);
        }
    }
}
