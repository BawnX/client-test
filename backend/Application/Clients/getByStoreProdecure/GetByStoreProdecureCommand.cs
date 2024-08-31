using Domain.Models;
using ErrorOr;
using MediatR;

namespace Application.Clients.GetByStore;

public record GetByStoreProdecureClientCommand(
    int currentPage = 1,
    int pageSize = 10
) : IRequest<ErrorOr<ICollection<ClientDtoStore>>>;
