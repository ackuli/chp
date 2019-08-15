using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class PackageMap : EntityTypeConfiguration<Package>
    {
        public PackageMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(8000);

            this.Property(t => t.Details)
                .IsRequired();

            this.Property(t => t.PriceType)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.StartFrom)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.SetBy)
                .IsRequired();

            this.Property(t => t.SetDate)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Packages");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.PackageSourceId).HasColumnName("PackageSourceId");
            this.Property(t => t.Details).HasColumnName("Details");
            this.Property(t => t.Duration).HasColumnName("Duration");
            this.Property(t => t.Price).HasColumnName("Price");
            this.Property(t => t.PriceType).HasColumnName("PriceType");
            this.Property(t => t.StartFrom).HasColumnName("StartFrom");
            this.Property(t => t.SetBy).HasColumnName("SetBy");
            this.Property(t => t.SetDate).HasColumnName("SetDate");

            // Relationships
            this.HasRequired(t => t.PackageSource)
                .WithMany(t => t.Packages)
                .HasForeignKey(d => d.PackageSourceId);

        }
    }
}
