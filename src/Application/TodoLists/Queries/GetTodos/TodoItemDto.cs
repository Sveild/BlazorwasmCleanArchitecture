using BlazorwasmCleanArchitecture.Application.Common.Mappings;
using BlazorwasmCleanArchitecture.Domain.Entities;
using Mapster;

namespace BlazorwasmCleanArchitecture.Application.TodoLists.Queries.GetTodos;

public class TodoItemDto : IMapFrom<TodoItem>
{
    public int Id { get; set; }

    public int ListId { get; set; }

    public string? Title { get; set; }

    public bool Done { get; set; }

    public int Priority { get; set; }

    public string? Note { get; set; }

    public void Mapping()
    {
        TypeAdapterConfig<TodoItem, TodoItemDto>
            .NewConfig()
            .Map(dest => dest.Priority, src => (int) src.Priority);
    }
}
