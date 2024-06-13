using CleanArchitecture.Application.Common.Interfaces.Data;

namespace CleanArchitecture.Infrastructure.Data;

public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    public Task SaveChanges()
    {
        return dbContext.SaveChangesAsync();
    }
}