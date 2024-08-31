using Domain.Models;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class ClientLinqRepository : IClientRepositoryLinq
{
  private readonly ApplicationDbContext _context;

  public ClientLinqRepository(ApplicationDbContext context)
  {
    _context = context ?? throw new ArgumentNullException(nameof(context));
  }

  public async Task<int> Count()
  {
    return await _context.Clients.CountAsync();
  }

  public async Task<ICollection<Client>> GetPagination(int page, int pageSize) => await _context.Clients
  .OrderBy(c => c.Id)
  .Skip((page - 1) * pageSize)
  .Take(pageSize)
  .Select(c => new Client
  {
    Id = c.Id,
    Country = c.Country,
    CreatedAt = c.CreatedAt,
    LastName = c.LastName,
    Name = c.Name,
    Phones = c.Phones,
    UpdatedAt = c.UpdatedAt
  })
  .ToListAsync();
}
