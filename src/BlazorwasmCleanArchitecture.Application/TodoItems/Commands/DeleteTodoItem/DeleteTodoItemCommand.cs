using MediatR;

namespace BlazorwasmCleanArchitecture.Application.TodoItems.Commands.DeleteTodoItem;

public record DeleteTodoItemCommand(int Id) : IRequest;