using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using Checkout.Api.HttpClientServices.MerchantManagement.Models;

namespace Checkout.Api.HttpClientServices.MerchantManagement
{
    public class MerchantManagementClient : BaseHttpClient, IMerchantManagementClient
    {
        public MerchantManagementClient(HttpClient client) : base(client)
        {
        }

        public async Task<IEnumerable<Merchant>> GetMerchants()
        {
            return await Get<IEnumerable<Merchant>>("merchant");
        }

        public async Task<Merchant> GetMerchant(Guid merchantId)
        {
            return await Get<Merchant>($"merchant/{merchantId}");
        }

        public async Task<Guid> CreateMerchant(CreateMerchant merchant)
        {
            //var response = await HttpClient.PostAsJsonAsync($"{HttpClient.BaseAddress}merchant", merchant);
            //var content = await response.Content.ReadAsStringAsync();
            //try
            //{
            //    response.EnsureSuccessStatusCode();
            //}
            //catch (HttpRequestException e)
            //{
            //    if (response.StatusCode == HttpStatusCode.BadRequest)
            //    {
            //        var validation =  JsonSerializer.Deserialize<IEnumerable<ValidationFailure>>(content);
            //        throw new Checkout.Api.Exception.ValidationException(validation);
            //    }

            //    throw;
            //}

            return await Post<CreateMerchant, Guid>("merchant", merchant);
        }
    }
}
