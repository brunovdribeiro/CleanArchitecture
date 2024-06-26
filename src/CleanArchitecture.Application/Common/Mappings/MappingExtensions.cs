using CleanArchitecture.Application.Common.Models;

using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Common.Mappings;

public static class MappingExtensions
{
    public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable,
        int pageNumber,
        int pageSize) where TDestination : class
    {
        return PaginatedList<TDestination>.CreateAsync(queryable.AsNoTracking(), pageNumber, pageSize);
    }
}