using Domain.Countries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
  public void Configure(EntityTypeBuilder<Country> builder)
  {
    builder.ToTable("countries");

    builder.HasKey(c => c.Id);

    builder.Property(c => c.Id)
        .HasColumnName("id")
        .UseIdentityAlwaysColumn();

    builder.Property(c => c.Name)
        .HasColumnName("name")
        .HasMaxLength(30)
        .IsRequired();

    builder.Property(c => c.Code)
        .HasColumnName("code")
        .HasMaxLength(5)
        .IsRequired();

    builder.Property(c => c.CreatedAt)
        .HasColumnName("created_at")
        .HasDefaultValueSql("now()");

    builder.Property(c => c.UpdatedAt)
        .HasColumnName("updated_at")
        .HasDefaultValueSql("now()");

    builder.HasIndex(c => c.Name)
        .HasDatabaseName("idx_countries_name");

    builder.HasIndex(c => c.Code)
        .IsUnique();
  }
}
