using Domain.Models;
using ErrorOr;
using MediatR;

namespace Application.Clients.GetByLinq;

public record GetByLinqClientCommand(
    int currentPage = 1,
    int pageSize = 10
) : IRequest<ErrorOr<ICollection<ClientDtoLinq>>>;
