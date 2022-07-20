﻿using BlazorwasmCleanArchitecture.Domain.Common;
using BlazorwasmCleanArchitecture.Domain.Entities;

namespace BlazorwasmCleanArchitecture.Domain.Events;

public class TodoItemCreatedEvent : BaseEvent
{
    public TodoItemCreatedEvent(TodoItem item)
    {
        Item = item;
    }

    public TodoItem Item { get; }
}