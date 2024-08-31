namespace Domain.Repositories;
public interface IGenericRepository<T> where T : class
{
  Task<IEnumerable<T>> GetAllAsync();
  Task<T> GetByIdAsync(int id);
  Task<IEnumerable<T>> GetPaginationAsync(int currentPage, int pageSize);
  Task AddAsync(T entity);
  Task UpdateAsync(T entity);
  Task DeleteAsync(int id);
  Task<IEnumerable<T>> FromSqlInterpolatedAsync(FormattableString sql);
}
