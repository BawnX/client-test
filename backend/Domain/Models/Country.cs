using System;
using Domain.Models;
using Domain.Phones;
using Domain.Primitives;

namespace Domain.Countries;

public sealed class Country : AggregateRoot
{
  public long Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public string Code { get; set; } = string.Empty;
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
  public ICollection<Client> Client { get; set; } = new List<Client>();
  public ICollection<Phone> Phones { get; set; } = new List<Phone>();
}
