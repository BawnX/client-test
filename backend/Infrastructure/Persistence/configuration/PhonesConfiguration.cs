using Domain.Phones;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class PhoneConfiguration : IEntityTypeConfiguration<Phone>
{
  public void Configure(EntityTypeBuilder<Phone> builder)
  {
    builder.ToTable("phones");

    builder.HasKey(p => p.Id);

    builder.Property(p => p.Id)
        .HasColumnName("id")
        .UseIdentityAlwaysColumn();

    builder.Property(p => p.Number)
        .HasColumnName("number")
        .HasMaxLength(12)
        .IsRequired();

    builder.Property(p => p.CountryId)
        .HasColumnName("country_id")
        .IsRequired();

    builder.Property(p => p.ClientId)
        .HasColumnName("client_id")
        .IsRequired();

    builder.Property(p => p.CreatedAt)
        .HasColumnName("created_at")
        .HasDefaultValueSql("now()");

    builder.Property(p => p.UpdatedAt)
        .HasColumnName("updated_at")
        .HasDefaultValueSql("now()");

    builder.HasOne(c => c.Country)
        .WithMany(ph => ph.Phones)
        .HasForeignKey(c => c.CountryId)
        .OnDelete(DeleteBehavior.Restrict);

    builder.HasOne(cl => cl.Client)
        .WithMany(ph => ph.Phones)
        .HasForeignKey(cl => cl.ClientId)
        .OnDelete(DeleteBehavior.Cascade);

    builder.HasIndex(p => p.Number)
        .IsUnique();

    builder.HasIndex(p => p.CountryId)
        .HasDatabaseName("idx_phones_country_id");

    builder.HasIndex(p => p.ClientId)
        .HasDatabaseName("idx_phones_client_id");
  }
}
