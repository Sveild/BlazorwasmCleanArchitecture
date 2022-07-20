using MediatR;

namespace BlazorwasmCleanArchitecture.Application.TodoLists.Queries.ExportTodos;

public record ExportTodosQuery : IRequest<ExportTodosVm>
{
    public int ListId { get; init; }
}