using System.Text.Json.Serialization;

namespace Checkout.Api.HttpClientServices
{
    public class ValidationFailure
    {
        public string PropertyName { get; set; }

        public string ErrorMessage { get; set; }
    }
}
