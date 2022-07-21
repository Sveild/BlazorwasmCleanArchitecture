using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Blazored.LocalStorage;
using BlazorwasmCleanArchitecture.Client.Providers;
using BlazorwasmCleanArchitecture.Client.Services.APIClients;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorwasmCleanArchitecture.Client.Services.Authentication;

public class AuthService : IAuthService
{
    private readonly HttpClient _httpClient;
    private readonly IAccountClient _accountClient;
    private readonly ILoginClient _loginClient;
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    private readonly ILocalStorageService _localStorage;

    public AuthService(
        HttpClient httpClient,
        IAccountClient accountClient,
        ILoginClient loginClient,
        AuthenticationStateProvider authenticationStateProvider,
        ILocalStorageService localStorage)
    {
        _httpClient = httpClient;
        _accountClient = accountClient;
        _loginClient = loginClient;
        _authenticationStateProvider = authenticationStateProvider;
        _localStorage = localStorage;
    }
    
    public async Task<RegisterDto> Register(RegisterCommand registerCommand)
    {
        var result = await _accountClient.RegisterAsync(registerCommand);
        return result;
    }
    
    public async Task<LoginDto> Login(LoginCommand loginCommand)
    {
        var response = await _loginClient.LoginAsync(loginCommand);

        if (!response.Successful)
        {
            return response;
        }
    
        await _localStorage.SetItemAsync("authToken", response.Token);
        ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginCommand.Email);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", response.Token);
    
        return response;
    }
    
    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync("authToken");
        ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
        _httpClient.DefaultRequestHeaders.Authorization = null;
    }
}