using BlazorwasmCleanArchitecture.Application.Common.Models;
using Microsoft.EntityFrameworkCore;
using Mapster;

namespace BlazorwasmCleanArchitecture.Application.Common.Mappings;

public static class MappingExtensions
{
    public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize) where TDestination : class
        => PaginatedList<TDestination>.CreateAsync(queryable.AsNoTracking(), pageNumber, pageSize);

    public static Task<List<TDestination>> AdaptToListAsync<TDestination>(this IQueryable queryable) where TDestination : class
        => queryable.Adapt<IQueryable<TDestination>>().AsNoTracking().ToListAsync();
}
