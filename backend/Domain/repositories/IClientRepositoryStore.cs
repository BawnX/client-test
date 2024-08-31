using Domain.Models;

namespace Domain.Repositories;
public interface IClientRepositoryStore
{
  Task<ICollection<ClientDtoStore>> GetPagination(int page, int pageSize);
}
