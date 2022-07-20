using MediatR;

namespace BlazorwasmCleanArchitecture.Application.TodoItems.Commands.CreateTodoItem;


public record CreateTodoItemCommand : IRequest<int>
{
    public int ListId { get; init; }
    
    public string? Title { get; init; }
}