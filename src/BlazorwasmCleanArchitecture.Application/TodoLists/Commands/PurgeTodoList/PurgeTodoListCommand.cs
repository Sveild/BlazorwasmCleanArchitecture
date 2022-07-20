using BlazorwasmCleanArchitecture.Application.Common.Security;
using MediatR;

namespace BlazorwasmCleanArchitecture.Application.TodoLists.Commands.PurgeTodoList;

[Authorize(Roles = "Administrator")]
[Authorize(Policy = "CanPurge")]
public record PurgeTodoListsCommand : IRequest;