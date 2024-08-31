using Domain.Models;
using Domain.Repositories;
using ErrorOr;
using MediatR;

namespace Application.Clients.GetByLinq;

public sealed class GetByLinqClientCommandHandler : IRequestHandler<GetByLinqClientCommand, ErrorOr<ICollection<ClientDtoLinq>>>
{
  private readonly IClientRepositoryLinq _clientRepository;
  public GetByLinqClientCommandHandler(IClientRepositoryLinq clientRepository)
  {
    _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
  }

  public async Task<ErrorOr<ICollection<ClientDtoLinq>>> Handle(GetByLinqClientCommand request, CancellationToken cancellationToken)
  {
    var clients = await _clientRepository
    .GetPagination(request.currentPage, request.pageSize);
    return clients.Select(cl => new ClientDtoLinq
    {
      Country = cl.Country.Name,
      FullName = cl.FullName,
      CreatedAt = cl.CreatedAt,
      Phones = cl.Phones.Select(ph => ph.PhoneNumber).ToList()
    }).ToList();
  }
}
