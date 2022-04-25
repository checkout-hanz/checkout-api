using Checkout.Api.HttpClientServices;

namespace Checkout.Api.Exception
{
    public class ValidationException : System.Exception
    {
        public IEnumerable<ValidationFailure>? ValidationFailures { get; private set; }

        public ValidationException(IEnumerable<ValidationFailure>? validationFailures)
        {
            ValidationFailures = validationFailures;
        }
    }
}
