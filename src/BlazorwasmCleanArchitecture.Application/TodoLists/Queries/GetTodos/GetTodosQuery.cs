using BlazorwasmCleanArchitecture.Application.Common.Security;
using MediatR;

namespace Application.TodoLists.Queries.GetTodos;

[Authorize]
public record GetTodosQuery : IRequest<TodosVm>;