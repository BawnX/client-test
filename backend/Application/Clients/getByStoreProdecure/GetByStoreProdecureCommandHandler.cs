using Application.Clients.GetByLinq;
using Domain.Models;
using Domain.Repositories;
using ErrorOr;
using MediatR;

namespace Application.Clients.GetByStore;

public sealed class GetByStoreProdecureClientCommandHandler : IRequestHandler<GetByStoreProdecureClientCommand, ErrorOr<PaginatedResult<ClientStore>>>
{
  private readonly IClientRepositoryStore _clientRepository;
  public GetByStoreProdecureClientCommandHandler(IClientRepositoryStore clientRepository)
  {
    _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
  }

  public async Task<ErrorOr<PaginatedResult<ClientStore>>> Handle(GetByStoreProdecureClientCommand request, CancellationToken cancellationToken)
  {
    var clients = await _clientRepository.GetPagination(request.currentPage, request.pageSize);
    var data = clients.ToList();

    return new PaginatedResult<ClientStore>
    {
      CurrentPage = request.currentPage,
      Data = clients.ToList(),
      TotalPages = data[0].TotalPages
    };
  }
}
