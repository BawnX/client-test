using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Data;

public interface IApplicationDbContext
{
  DbSet<Client> Clients { get; set; }

  Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
