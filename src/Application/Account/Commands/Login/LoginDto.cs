namespace BlazorwasmCleanArchitecture.Application.Account.Commands.Login;

public class LoginDto
{
    public bool Successful { get; set; }
    public string Error { get; set; }
    public string Token { get; set; }
}