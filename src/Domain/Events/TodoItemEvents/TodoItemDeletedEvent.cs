using BlazorwasmCleanArchitecture.Domain.Common;
using BlazorwasmCleanArchitecture.Domain.Entities;

namespace BlazorwasmCleanArchitecture.Domain.Events.TodoItemEvents;

public class TodoItemDeletedEvent : BaseEvent
{
    public TodoItemDeletedEvent(TodoItem item)
    {
        Item = item;
    }

    public TodoItem Item { get; }
}
