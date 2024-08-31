using Domain.Models;
using Domain.Repositories;
using ErrorOr;
using MediatR;

namespace Application.Clients.GetByLinq;

public sealed class GetByLinqClientCommandHandler : IRequestHandler<GetByLinqClientCommand, ErrorOr<PaginatedResult<ClientLinq>>>
{
  private readonly IClientRepositoryLinq _clientRepository;
  public GetByLinqClientCommandHandler(IClientRepositoryLinq clientRepository)
  {
    _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
  }

  public async Task<ErrorOr<PaginatedResult<ClientLinq>>> Handle(GetByLinqClientCommand request, CancellationToken cancellationToken)
  {
    var clients = await _clientRepository
    .GetPagination(request.currentPage, request.pageSize);
    var data = clients.Select(cl => new ClientLinq
    {
      Country = cl.Country.Name,
      FullName = cl.FullName,
      CreatedAt = cl.CreatedAt,
      Phones = cl.Phones.Select(ph => ph.PhoneNumber).ToList()
    }).ToList();
    return new PaginatedResult<ClientLinq>
    {
      CurrentPage = request.currentPage,
      Data = data,
      TotalPages = (await _clientRepository.Count()) / request.pageSize
    };
  }
}
