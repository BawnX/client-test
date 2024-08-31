using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Client>
{
  public void Configure(EntityTypeBuilder<Client> builder)
  {
    builder.ToTable("clients");

    builder.HasKey(c => c.Id);

    builder.Property(c => c.Id)
        .HasColumnName("id")
        .UseIdentityAlwaysColumn();

    builder.Property(c => c.Name)
        .HasColumnName("name")
        .HasMaxLength(30)
        .IsRequired();

    builder.Property(c => c.LastName)
        .HasColumnName("last_name")
        .HasMaxLength(30)
        .IsRequired();

    builder.Property(c => c.CountryId)
        .HasColumnName("country_id")
        .IsRequired();

    builder.Property(c => c.CreatedAt)
        .HasColumnName("created_at")
        .HasDefaultValueSql("now()");

    builder.Property(c => c.UpdatedAt)
        .HasColumnName("updated_at")
        .HasDefaultValueSql("now()");

    builder.HasOne(c => c.Country)
        .WithMany()
        .HasForeignKey(c => c.CountryId)
        .OnDelete(DeleteBehavior.Restrict);

    builder.HasIndex(c => c.CountryId)
        .HasDatabaseName("idx_clients_country_id");

    builder.HasIndex(c => new { c.Name, c.LastName })
        .HasDatabaseName("idx_clients_name_last_name");
  }
}
