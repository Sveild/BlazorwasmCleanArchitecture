using BlazorwasmCleanArchitecture.Application.Common.Models;
using MediatR;

namespace BlazorwasmCleanArchitecture.Application.TodoItems.Queries.GetTodoItems;

public record GetTodoItemsQuery : IRequest<PaginatedList<TodoItemBriefDto>>
{
    public int ListId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}