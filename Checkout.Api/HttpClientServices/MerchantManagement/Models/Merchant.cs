namespace Checkout.Api.HttpClientServices.MerchantManagement.Models
{
    public class Merchant
    {
        public Guid MerchantId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}
