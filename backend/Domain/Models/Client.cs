using System.ComponentModel;
using Domain.Countries;
using Domain.Phones;
using Domain.Primitives;

namespace Domain.Models;

public sealed class Client : AggregateRoot
{
  public long Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public string LastName { get; set; } = string.Empty;
  public string FullName => $"{Name} {LastName}";
  public long CountryId { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public required Country Country { get; set; }
  public ICollection<Phone> Phones { get; set; } = new List<Phone>();
}
