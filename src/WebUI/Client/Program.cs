using Blazored.LocalStorage;
using BlazorwasmCleanArchitecture.Client;
using BlazorwasmCleanArchitecture.Client.Providers;
using BlazorwasmCleanArchitecture.Client.Services;
using BlazorwasmCleanArchitecture.Client.Services.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("BlazorwasmCleanArchitecture.Client.ServerAPI", client =>
    {
        client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
    }
);

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddSingleton(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("BlazorwasmCleanArchitecture.Client.ServerAPI"));

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();

builder.Services.Scan(
    scan => scan
        .FromAssemblyOf<IScopedService>()
        .AddClasses(classes => classes.AssignableTo<ITransientService>())
        .AsMatchingInterface()
        .WithTransientLifetime()
        .AddClasses(classes => classes.AssignableTo<IScopedService>())
        .AsMatchingInterface()
        .WithScopedLifetime()
        .AddClasses(classes => classes.AssignableTo<ISingletonService>())
        .AsMatchingInterface()
        .WithSingletonLifetime()
);

await builder.Build().RunAsync();