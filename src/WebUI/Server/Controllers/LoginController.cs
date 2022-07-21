using BlazorwasmCleanArchitecture.Application.Account.Commands.Login;
using BlazorwasmCleanArchitecture.Application.Account.Commands.Register;
using Microsoft.AspNetCore.Mvc;

namespace BlazorwasmCleanArchitecture.Server.Controllers;

public class LoginController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<LoginDto>> Login([FromBody] LoginCommand command)
    {
        return await Mediator.Send(command);
    }
}