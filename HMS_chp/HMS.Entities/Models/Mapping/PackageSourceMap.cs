using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class PackageSourceMap : EntityTypeConfiguration<PackageSource>
    {
        public PackageSourceMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired();

            this.Property(t => t.SetBy)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("PackageSources");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.LogoId).HasColumnName("LogoId");
            this.Property(t => t.SetBy).HasColumnName("SetBy");
            this.Property(t => t.SetDate).HasColumnName("SetDate");

            // Relationships
            this.HasRequired(t => t.BinaryObject)
                .WithMany(t => t.PackageSources)
                .HasForeignKey(d => d.LogoId);

        }
    }
}
