using MediatR;

namespace BlazorwasmCleanArchitecture.Application.TodoLists.Commands.DeleteTodoList;

public record DeleteTodoListCommand(int Id) : IRequest;