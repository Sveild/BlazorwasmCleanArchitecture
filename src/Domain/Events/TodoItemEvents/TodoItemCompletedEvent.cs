using BlazorwasmCleanArchitecture.Domain.Common;
using BlazorwasmCleanArchitecture.Domain.Entities;

namespace BlazorwasmCleanArchitecture.Domain.Events.TodoItemEvents;

public class TodoItemCompletedEvent : BaseEvent
{
    public TodoItemCompletedEvent(TodoItem item)
    {
        Item = item;
    }

    public TodoItem Item { get; }
}
