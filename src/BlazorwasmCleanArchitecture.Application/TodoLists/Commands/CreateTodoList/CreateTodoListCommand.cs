using MediatR;

namespace BlazorwasmCleanArchitecture.Application.TodoLists.Commands.CreateTodoList;

public record CreateTodoListCommand : IRequest<int>
{
    public string? Title { get; init; }
}