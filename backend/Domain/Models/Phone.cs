using System;
using Domain.Primitives;
using Domain.Countries;
using Domain.Models;

namespace Domain.Phones;

public sealed class Phone : AggregateRoot
{
  public long Id { get; set; }
  public string Number { get; set; } = string.Empty;
  public string PhoneNumber => $"{Country.Code}{Number}";
  public long CountryId { get; set; }
  public long ClientId { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }

  public required Country Country { get; set; }
  public required Client Client { get; set; }
}
