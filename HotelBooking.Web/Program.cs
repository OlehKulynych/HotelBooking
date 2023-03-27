using Blazored.LocalStorage;
using HotelBooking.Web;
using HotelBooking.Web.Providers;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddAuthorizationCore();

builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7114/") });


builder.Services.AddScoped<AuthenticationStateProvider, ClientAuthenticationStateProvider>();
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
