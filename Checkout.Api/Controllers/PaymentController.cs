using Checkout.Api.HttpClientServices.PaymentGateway;
using Checkout.Api.HttpClientServices.PaymentGateway.Models;
using Checkout.Api.HttpClientServices.TransactionProjection;
using Checkout.Api.HttpClientServices.TransactionProjection.Models;
using Microsoft.AspNetCore.Mvc;

namespace Checkout.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentGatewayClient _paymentGatewayClient;
        private readonly ITransactionProjectionClient _transactionProjection;

        public PaymentController(IPaymentGatewayClient paymentGatewayClient, ITransactionProjectionClient transactionProjection)
        {
            _paymentGatewayClient = paymentGatewayClient;
            _transactionProjection = transactionProjection;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TransactionResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(TransactionResponse))]
        public async Task<IActionResult> Create(CreateTransaction transaction)
        {
            var response = await _paymentGatewayClient.MakePayment(transaction);
            return Ok(response);
        }


        [HttpGet("{merchantId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Transaction>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid merchantId)
        {
            var response = await _transactionProjection.GetTransactions(merchantId);
            return Ok(response);
        }
    }
}
