namespace CleanArchitecture.Application.Common.Interfaces.Data;

public interface IUnitOfWork
{
    Task SaveChanges();
}