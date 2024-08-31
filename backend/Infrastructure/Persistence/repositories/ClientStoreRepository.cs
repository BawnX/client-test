using System.Data.SqlTypes;
using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Infrastructure.Persistence.Repositories;

public class ClientStoreRepository : IClientRepositoryStore
{
  private readonly ApplicationDbContext _context;

  public ClientStoreRepository(ApplicationDbContext context)
  {
    _context = context ?? throw new ArgumentNullException(nameof(context));
  }
  public async Task<ICollection<ClientStore>> GetPagination(int page, int pageSize)
  {
    var result = await _context.Set<ClientStore>().FromSqlInterpolated($@"SELECT * FROM get_client_info({page}, {pageSize})")
     .ToListAsync();

    return result;
  }


}
