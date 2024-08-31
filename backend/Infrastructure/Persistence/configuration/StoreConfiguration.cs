using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class ClientDtoStoreConfiguration : IEntityTypeConfiguration<ClientDtoStore>
{
  public void Configure(EntityTypeBuilder<ClientDtoStore> builder)
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
  }
}
