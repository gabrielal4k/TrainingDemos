using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using TodoApp.Portal;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.HostEnvironment.BaseAddress = "https://localhost:4000";

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:4000") });
builder.Services.AddMudServices();

await builder.Build().RunAsync();
