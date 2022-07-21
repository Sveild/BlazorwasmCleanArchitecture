using BlazorwasmCleanArchitecture.Application.Common.Interfaces;
using BlazorwasmCleanArchitecture.Application.TodoItems.Commands.CreateTodoItem;
using MediatR;

namespace BlazorwasmCleanArchitecture.Application.Account.Commands.Register;

public class RegisterCommand : IRequest<RegisterDto>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterDto>
{
    private readonly IIdentityService _identityService;
    
    public RegisterCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }
    
    public async Task<RegisterDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var (result, id) = await _identityService.CreateUserAsync(request.Email, request.Password);
        return new RegisterDto {Successful = result.Succeeded, Errors = result.Errors};
    }
}