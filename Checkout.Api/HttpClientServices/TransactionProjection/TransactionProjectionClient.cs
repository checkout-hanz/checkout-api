using Checkout.Api.HttpClientServices.TransactionProjection.Models;

namespace Checkout.Api.HttpClientServices.TransactionProjection
{
    public class TransactionProjectionClient : BaseHttpClient, ITransactionProjectionClient
    {
        public TransactionProjectionClient(HttpClient client) : base(client)
        {
        }

        public async Task<IEnumerable<Transaction>> GetTransactions(Guid merchantId)
        {
            return await Get<IEnumerable<Transaction>>($"payment/{merchantId}");
        }
    }
}
