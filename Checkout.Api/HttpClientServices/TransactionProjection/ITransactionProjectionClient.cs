using Checkout.Api.HttpClientServices.TransactionProjection.Models;

namespace Checkout.Api.HttpClientServices.TransactionProjection
{
    public interface ITransactionProjectionClient
    {
        Task<IEnumerable<Transaction>> GetTransactions(Guid merchantId);
    }
}
