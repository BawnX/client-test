namespace Domain.Models;
public sealed class PaginatedResult<T>
{
  public ICollection<T> Data { get; set; } = new List<T>();
  public int CurrentPage { get; set; }
  public int TotalPages { get; set; }
}
