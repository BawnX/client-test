using Domain.Models;

namespace Domain.Repositories;
public interface IClientRepositoryLinq
{
  Task<ICollection<Client>> GetPagination(int page, int pageSize);
}
