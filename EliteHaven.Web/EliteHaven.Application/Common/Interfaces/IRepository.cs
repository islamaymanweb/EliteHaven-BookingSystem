namespace EliteHaven.Application.Common.Interfaces;

public interface IRepository<T> where T : class
{
    
    public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);

   
    public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null);

    
    public void Add(T entity);

    public void Delete(T entity);

    public bool Any(Expression<Func<T, bool>> filter);
}
