namespace Template.Infrastructure;

public interface IRepository<T>
    where T : class
{
    IQueryable<T> GetAll();

    Task Add(IEnumerable<T> entities);

    Task Add(T entity);

    Task Update(IEnumerable<T> entities);

    Task Update(T entity);

    Task Delete(IEnumerable<T> entities);

    Task Delete(T entity);
    Task SaveChanges(T entity);
}