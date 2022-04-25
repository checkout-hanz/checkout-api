using Checkout.Api.HttpClientServices.MerchantManagement.Models;

namespace Checkout.Api.HttpClientServices.MerchantManagement
{
    public interface IMerchantManagementClient
    {
        Task<IEnumerable<Merchant>> GetMerchants();
        Task<Merchant> GetMerchant(Guid MerchantId);
        Task<Guid> CreateMerchant(CreateMerchant merchant);
    }
}
