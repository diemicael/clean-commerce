namespace CleanCommerce.Domain.Abstractions;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAll();
    Task<T?> GetById(int id);
    Task<int> Add(T entity);
    Task Update(T entity);
    Task<int> Delete(int id);
}