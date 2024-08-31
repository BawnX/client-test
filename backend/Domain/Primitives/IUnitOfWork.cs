namespace Domain.Primitives;

public interface IUnitOfWork
{
    Task<int> SaveChangeSync(CancellationToken cancellationToken = default);
}