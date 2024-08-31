using Application.Data;
using Domain.Models;
using Domain.Primitives;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext, IUnitOfWork
{
  private readonly IPublisher _publisher;

  public ApplicationDbContext(DbContextOptions options, IPublisher publisher) : base(options)
  {
    _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
  }

  public DbSet<Client> Clients { get; set; }

  public async Task<int> SaveChangeSync(CancellationToken cancellationToken = new CancellationToken())
  {
    var domainEvents = ChangeTracker.Entries<AggregateRoot>()
    .Select(e => e.Entity)
    .Where(e => e.GetDomainEvents().Any())
    .SelectMany(e => e.GetDomainEvents());

    var result = await base.SaveChangesAsync(cancellationToken);

    foreach (var domainEvent in domainEvents)
    {
      await _publisher.Publish(domainEvent, cancellationToken);
    }

    return result;
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
  }
}
