﻿using BlazorwasmCleanArchitecture.Domain.Events;
using BlazorwasmCleanArchitecture.Domain.Events.TodoItemEvents;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BlazorwasmCleanArchitecture.Application.TodoItems.EventHandlers;

public class TodoItemCreatedEventHandler : INotificationHandler<TodoItemCreatedEvent>
{
    private readonly ILogger<TodoItemCreatedEventHandler> _logger;

    public TodoItemCreatedEventHandler(ILogger<TodoItemCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(TodoItemCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("BlazorwasmCleanArchitecture Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
