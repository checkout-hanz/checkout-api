using System.Net;
using Checkout.Api.HttpClientServices.PaymentGateway.Models;

namespace Checkout.Api.HttpClientServices.PaymentGateway
{
    public class PaymentGatewayClient : BaseHttpClient, IPaymentGatewayClient
    {
        public PaymentGatewayClient(HttpClient client) : base(client)
        {
        }

        public async Task<TransactionResponse> MakePayment(CreateTransaction createTransaction)
        {
            return await Post<CreateTransaction, TransactionResponse>($"payment", createTransaction);
        }
    }
}
