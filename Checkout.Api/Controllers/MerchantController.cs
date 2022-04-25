using Checkout.Api.HttpClientServices.MerchantManagement;
using Microsoft.AspNetCore.Mvc;
using Models = Checkout.Api.HttpClientServices.MerchantManagement.Models;

namespace Checkout.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MerchantController : ControllerBase
    {
        private readonly IMerchantManagementClient _merchantManagementClient;

        public MerchantController(IMerchantManagementClient merchantManagementClient)
        {
            _merchantManagementClient = merchantManagementClient;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Models.Merchant>))]
        public async Task<IActionResult> GetMerchants()
        {
            return Ok(await _merchantManagementClient.GetMerchants());
        }

        [HttpGet("{merchantId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Models.Merchant>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMerchant(Guid merchantId)
        {
            var merchant = await _merchantManagementClient.GetMerchant(merchantId);
            if (merchant == null)
            {
                return NotFound();
            }

            return Ok(merchant);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(Models.CreateMerchant merchant)
        {
            var merchantId = await _merchantManagementClient.CreateMerchant(merchant);
            return CreatedAtAction(nameof(GetMerchant), new { merchantId = merchantId }, merchantId);
        }
    }
}
