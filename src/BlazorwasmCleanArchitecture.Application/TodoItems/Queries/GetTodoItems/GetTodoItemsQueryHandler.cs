using BlazorwasmCleanArchitecture.Application.Common.Interfaces;
using BlazorwasmCleanArchitecture.Application.Common.Mappings;
using BlazorwasmCleanArchitecture.Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;

namespace BlazorwasmCleanArchitecture.Application.TodoItems.Queries.GetTodoItems;

public class GetTodoItemsQueryHandler : IRequestHandler<GetTodoItemsQuery, PaginatedList<TodoItemBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTodoItemsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<TodoItemBriefDto>> Handle(GetTodoItemsQuery request, CancellationToken cancellationToken)
    {
        return await _context.TodoItems
            .Where(x => x.ListId == request.ListId)
            .OrderBy(x => x.Title)
            .ProjectTo<TodoItemBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}