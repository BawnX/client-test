using Domain.Primitives;

namespace Domain.Models;

public sealed class ClientStore : AggregateRoot
{
  public long id { get; set; }
  public string FullName { get; set; } = string.Empty;
  public DateTime CreatedAt { get; set; }
  public string CountryName { get; set; } = string.Empty;
  public string PhoneNumber { get; set; } = string.Empty;
  public Int32 TotalPages { get; set; }
  public Int32 CurrentPage { get; set; }
}
