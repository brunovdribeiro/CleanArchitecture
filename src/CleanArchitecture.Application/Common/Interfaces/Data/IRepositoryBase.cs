namespace CleanArchitecture.Application.Common.Interfaces.Data;

public interface IRepositoryBase<T>
{
    Task Add(T obj);
    Task Update(T obj);
    Task Delete(T obj);
    Task<T> GetById();
    Task<ICollection<T>> Get();
}