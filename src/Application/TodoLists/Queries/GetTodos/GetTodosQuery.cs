using BlazorwasmCleanArchitecture.Application.Common.Interfaces;
using BlazorwasmCleanArchitecture.Application.Common.Security;
using BlazorwasmCleanArchitecture.Domain.Enums;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlazorwasmCleanArchitecture.Application.TodoLists.Queries.GetTodos;

[Authorize]
public record GetTodosQuery : IRequest<TodosVm>;

public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, TodosVm>
{
    private readonly IApplicationDbContext _context;

    public GetTodosQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TodosVm> Handle(GetTodosQuery request, CancellationToken cancellationToken)
    {
        return new TodosVm
        {
            PriorityLevels = Enum.GetValues(typeof(PriorityLevel))
                .Cast<PriorityLevel>()
                .Select(p => new PriorityLevelDto { Value = (int)p, Name = p.ToString() })
                .ToList(),

            Lists = await _context.TodoLists
                .AsNoTracking()
                .Adapt<IQueryable<TodoListDto>>()
                .OrderBy(t => t.Title)
                .ToListAsync(cancellationToken)
        };
    }
}
