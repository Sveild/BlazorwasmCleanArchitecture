using BlazorwasmCleanArchitecture.Application.Common.Interfaces;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlazorwasmCleanArchitecture.Application.TodoLists.Queries.ExportTodos;

public record ExportTodosQuery : IRequest<ExportTodosVm>
{
    public int ListId { get; init; }
}

public class ExportTodosQueryHandler : IRequestHandler<ExportTodosQuery, ExportTodosVm>
{
    private readonly IApplicationDbContext _context;
    private readonly ICsvFileBuilder _fileBuilder;

    public ExportTodosQueryHandler(IApplicationDbContext context, ICsvFileBuilder fileBuilder)
    {
        _context = context;
        _fileBuilder = fileBuilder;
    }

    public async Task<ExportTodosVm> Handle(ExportTodosQuery request, CancellationToken cancellationToken)
    {
        var records = await _context.TodoItems
            .Where(t => t.ListId == request.ListId)
            .Adapt<IQueryable<TodoItemRecord>>()
            .ToListAsync(cancellationToken);

        var vm = new ExportTodosVm(
            "TodoItems.csv",
            "text/csv",
            _fileBuilder.BuildTodoItemsFile(records)
        );

        return vm;
    }
}