using Domain.Countries;
using Domain.Phones;
using Domain.Primitives;

namespace Domain.Models;

public sealed class ClientDtoLinq : AggregateRoot
{
  public string FullName { get; set; } = string.Empty;
  public DateTime CreatedAt { get; set; }
  public string Country { get; set; } = string.Empty;
  public ICollection<string> Phones { get; set; } = new List<string>();
}
