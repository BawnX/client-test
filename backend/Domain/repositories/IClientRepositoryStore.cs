using Domain.Models;

namespace Domain.Repositories;
public interface IClientRepositoryStore
{
  Task<ICollection<ClientStore>> GetPagination(int page, int pageSize);
}
