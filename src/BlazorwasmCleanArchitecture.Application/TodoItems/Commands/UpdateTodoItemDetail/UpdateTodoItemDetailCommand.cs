using BlazorwasmCleanArchitecture.Domain.Enums;
using MediatR;

namespace BlazorwasmCleanArchitecture.Application.TodoItems.Commands.UpdateTodoItemDetail;

public record UpdateTodoItemDetailCommand : IRequest
{
    public int Id { get; init; }

    public int ListId { get; init; }

    public PriorityLevel Priority { get; init; }

    public string? Note { get; init; }
}