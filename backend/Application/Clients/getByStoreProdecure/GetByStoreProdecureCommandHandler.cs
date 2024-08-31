using Application.Clients.GetByLinq;
using Domain.Models;
using Domain.Repositories;
using ErrorOr;
using MediatR;

namespace Application.Clients.GetByStore;

public sealed class GetByStoreProdecureClientCommandHandler : IRequestHandler<GetByStoreProdecureClientCommand, ErrorOr<ICollection<ClientDtoStore>>>
{
  private readonly IClientRepositoryStore _clientRepository;
  public GetByStoreProdecureClientCommandHandler(IClientRepositoryStore clientRepository)
  {
    _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
  }

  public async Task<ErrorOr<ICollection<ClientDtoStore>>> Handle(GetByStoreProdecureClientCommand request, CancellationToken cancellationToken)
  {
    var clients = await _clientRepository.GetPagination(request.currentPage, request.pageSize);

    return clients.ToList();
  }
}
