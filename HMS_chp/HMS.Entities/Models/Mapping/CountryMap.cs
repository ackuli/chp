using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class CountryMap : EntityTypeConfiguration<Country>
    {
        public CountryMap()
        {
            // Primary Key
            this.HasKey(t => t.CountryId);

            // Properties
            this.Property(t => t.CountryName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.CountryCode)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Country");
            this.Property(t => t.CountryId).HasColumnName("CountryId");
            this.Property(t => t.CountryName).HasColumnName("CountryName");
            this.Property(t => t.CountryCode).HasColumnName("CountryCode");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
        }
    }
}
