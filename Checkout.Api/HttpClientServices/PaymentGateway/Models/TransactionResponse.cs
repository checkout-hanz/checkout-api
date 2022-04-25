namespace Checkout.Api.HttpClientServices.PaymentGateway.Models
{
    public class TransactionResponse
    {
        public Guid TransactionId { get; set; }
        public PaymentTransactionStatus Status { get; set; }
    }
}
