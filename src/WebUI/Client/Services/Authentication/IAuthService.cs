using BlazorwasmCleanArchitecture.Client.Services.APIClients;

namespace BlazorwasmCleanArchitecture.Client.Services.Authentication;

public interface IAuthService
{
    Task<RegisterDto> Register(RegisterCommand registerCommand);
    Task<LoginDto> Login(LoginCommand loginCommand);
    Task Logout();
}