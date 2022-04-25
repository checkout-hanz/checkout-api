using System.Text.Json;
using System.Text.Json.Serialization;
using Checkout.Api.Configuration;
using Checkout.Api.HttpClientServices.MerchantManagement;
using Checkout.Api.HttpClientServices.PaymentGateway;
using Checkout.Api.HttpClientServices.TransactionProjection;
using Checkout.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);
//builder.WebHost.UseUrls("http://0.0.0.0:8084");
// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options => {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        //options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    }); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks();

var serviceConfigCollection = builder.Configuration.BindConfigurationSection<ServiceConfigCollection>("Services");
ConfigureHttpClientFor<IMerchantManagementClient, MerchantManagementClient>(builder.Services, serviceConfigCollection[ServiceConfigNames.MerchantManagement]);
ConfigureHttpClientFor<IPaymentGatewayClient, PaymentGatewayClient>(builder.Services, serviceConfigCollection[ServiceConfigNames.PaymentGateway]);
ConfigureHttpClientFor<ITransactionProjectionClient, TransactionProjectionClient>(builder.Services, serviceConfigCollection[ServiceConfigNames.TransactionProjection]);

var app = builder.Build();

// Configure the HTTP request pipeline.


const string healthCheckEndpointPath = "/api/health";
app.MapHealthChecks(healthCheckEndpointPath);
app.UseMiddleware<GlobalExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


static void ConfigureHttpClientFor<T, TImplementation>(IServiceCollection services, ServiceConfig serviceConfig)
    where TImplementation : class, T where T : class
{
    services.AddHttpClient<T, TImplementation>(c =>
    {
        c.BaseAddress = new Uri(serviceConfig.BaseUrl);
        c.Timeout = TimeSpan.FromSeconds(serviceConfig.TimeOutSeconds);
    });
}

