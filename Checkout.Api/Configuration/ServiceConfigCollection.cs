namespace Checkout.Api.Configuration
{
    public interface IServiceConfigCollection
    {
        ServiceConfig this[string name] { get; }
    }

    public class ServiceConfigCollection : Dictionary<string, ServiceConfig>, IServiceConfigCollection
    {
    }
}
