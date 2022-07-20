using BlazorwasmCleanArchitecture.Application.Common.Mappings;
using BlazorwasmCleanArchitecture.Domain.Entities;

namespace BlazorwasmCleanArchitecture.Application.TodoLists.Queries.ExportTodos;

public class TodoItemRecord : IMapFrom<TodoItem>
{
    public string? Title { get; set; }

    public bool Done { get; set; }
}