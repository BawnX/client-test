using Domain.Primitives;

namespace Domain.Models;

public sealed class ClientDtoStore : AggregateRoot
{
  public long id { get; set; }
  public string FullName { get; set; } = string.Empty;
  public DateTime CreatedAt { get; set; }
  public string CountryName { get; set; } = string.Empty;
  public string PhoneNumber { get; set; } = string.Empty;
}
