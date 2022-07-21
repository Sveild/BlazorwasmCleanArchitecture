using BlazorwasmCleanArchitecture.Application.Common.Interfaces;
using MediatR;

namespace BlazorwasmCleanArchitecture.Application.Account.Commands.Login;

public class LoginCommand : IRequest<LoginDto>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public bool RememberMe { get; set; }
}

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginDto>
{
    private readonly IIdentityService _identityService;
    
    public LoginCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }
    
    public async Task<LoginDto> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var (result, token) =  await _identityService.LoginUserAsync(request.Email, request.Password);
        return new LoginDto {Successful = result.Succeeded, Error = string.Join(", ", result.Errors), Token = token};
    }
}