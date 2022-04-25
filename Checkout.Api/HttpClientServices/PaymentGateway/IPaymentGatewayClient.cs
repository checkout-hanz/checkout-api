using Checkout.Api.HttpClientServices.PaymentGateway.Models;

namespace Checkout.Api.HttpClientServices.PaymentGateway
{
    public interface IPaymentGatewayClient
    {
        Task<TransactionResponse> MakePayment(CreateTransaction createTransaction);
    }
}
