using BlazorMediatr.Client.RestClients.Api;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<Program>());

builder.Services.AddHttpClient("ApiClient", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://localhost:7165/");
});

builder.Services.AddTransient<IApiClient>(services =>
{
    return new ApiClient(services.GetRequiredService<IHttpClientFactory>().CreateClient("ApiClient"));
});

await builder.Build().RunAsync();