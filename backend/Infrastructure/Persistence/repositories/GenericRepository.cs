using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
  protected readonly DbContext _context;
  protected readonly DbSet<T> _dbSet;

  public GenericRepository(DbContext context)
  {
    _context = context;
    _dbSet = context.Set<T>();
  }

  public Task AddAsync(T entity)
  {
    throw new NotImplementedException();
  }

  public Task DeleteAsync(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<T>> GetAllAsync()
  {
    throw new NotImplementedException();
  }

  public Task<T> GetByIdAsync(int id)
  {
    throw new NotImplementedException();
  }

  public Task<IEnumerable<T>> GetPaginationAsync(int currentPage, int pageSize)
  {
    throw new NotImplementedException();
  }

  public Task UpdateAsync(T entity)
  {
    throw new NotImplementedException();
  }

  public async Task<IEnumerable<T>> FromSqlInterpolatedAsync(FormattableString sql)
  {
    return await _dbSet.FromSqlInterpolated(sql).ToListAsync();
  }
}
