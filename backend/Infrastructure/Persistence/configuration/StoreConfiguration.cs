using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class ClientDtoStoreConfiguration : IEntityTypeConfiguration<ClientStore>
{
  public void Configure(EntityTypeBuilder<ClientStore> builder)
  {
    builder.ToFunction("get_client_info");

    builder.HasKey(c => c.id);

    builder.Property(c => c.id)
        .HasColumnName("id")
        .UseIdentityAlwaysColumn();

    builder.Property(c => c.FullName)
        .HasColumnName("fullName");

    builder.Property(c => c.PhoneNumber)
        .HasColumnName("phoneNumber");

    builder.Property(c => c.CountryName)
        .HasColumnName("countryName");

    builder.Property(c => c.CreatedAt)
        .HasColumnName("createdAt");

    builder.Property(c => c.CurrentPage)
        .HasColumnName("currentPage");

    builder.Property(c => c.TotalPages)
        .HasColumnName("totalPages");
  }
}
