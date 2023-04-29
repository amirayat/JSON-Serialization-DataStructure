using Microsoft.EntityFrameworkCore;

namespace dotnet;

public partial class BenchmarkContext : DbContext
{
    public BenchmarkContext()
    {
    }

    public BenchmarkContext(DbContextOptions<BenchmarkContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("countries_pkey");

            entity.ToTable("countries");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Capital)
                .HasMaxLength(20)
                .HasColumnName("capital");
            entity.Property(e => e.Currency)
                .HasMaxLength(3)
                .HasColumnName("currency");
            entity.Property(e => e.CurrencyName)
                .HasMaxLength(39)
                .HasColumnName("currency_name");
            entity.Property(e => e.CurrencySymbol)
                .HasMaxLength(6)
                .HasColumnName("currency_symbol");
            entity.Property(e => e.Emoji)
                .HasMaxLength(2)
                .HasColumnName("emoji");
            entity.Property(e => e.EmojiU)
                .HasMaxLength(15)
                .HasColumnName("emojiU");
            entity.Property(e => e.Iso2)
                .HasMaxLength(2)
                .HasColumnName("iso2");
            entity.Property(e => e.Iso3)
                .HasMaxLength(3)
                .HasColumnName("iso3");
            entity.Property(e => e.Latitude)
                .HasMaxLength(12)
                .HasColumnName("latitude");
            entity.Property(e => e.Longitude)
                .HasMaxLength(13)
                .HasColumnName("longitude");
            entity.Property(e => e.Name)
                .HasMaxLength(36)
                .HasColumnName("name");
            entity.Property(e => e.Native)
                .HasMaxLength(50)
                .HasColumnName("native");
            entity.Property(e => e.NumericCode)
                .HasMaxLength(3)
                .HasColumnName("numeric_code");
            entity.Property(e => e.PhoneCode)
                .HasMaxLength(16)
                .HasColumnName("phone_code");
            entity.Property(e => e.Region)
                .HasMaxLength(8)
                .HasColumnName("region");
            entity.Property(e => e.Subregion)
                .HasMaxLength(25)
                .HasColumnName("subregion");
            entity.Property(e => e.Timezones).HasColumnName("timezones");
            entity.Property(e => e.Tld)
                .HasMaxLength(3)
                .HasColumnName("tld");
            entity.Property(e => e.Translations).HasColumnName("translations");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
