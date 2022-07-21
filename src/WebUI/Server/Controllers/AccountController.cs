using BlazorwasmCleanArchitecture.Application.Account.Commands.Register;
using BlazorwasmCleanArchitecture.Application.TodoItems.Commands.CreateTodoItem;
using Microsoft.AspNetCore.Mvc;

namespace BlazorwasmCleanArchitecture.Server.Controllers;

public class AccountController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<RegisterDto>> Register([FromBody] RegisterCommand command)
    {
        return await Mediator.Send(command);   
    }
}