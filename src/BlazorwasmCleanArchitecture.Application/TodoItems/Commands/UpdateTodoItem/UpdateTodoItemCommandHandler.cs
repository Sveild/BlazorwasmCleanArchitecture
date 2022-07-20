using BlazorwasmCleanArchitecture.Application.Common.Exceptions;
using BlazorwasmCleanArchitecture.Application.Common.Interfaces;
using BlazorwasmCleanArchitecture.Domain.Entities;
using MediatR;

namespace BlazorwasmCleanArchitecture.Application.TodoItems.Commands.UpdateTodoItem;

public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateTodoItemCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateTodoItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.TodoItems
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(TodoItem), request.Id);
        }

        entity.Title = request.Title;
        entity.Done = request.Done;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}