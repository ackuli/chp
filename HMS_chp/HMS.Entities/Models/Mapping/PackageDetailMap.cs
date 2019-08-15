using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class PackageDetailMap : EntityTypeConfiguration<PackageDetail>
    {
        public PackageDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("PackageDetails");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.PackageId).HasColumnName("PackageId");
            this.Property(t => t.Details).HasColumnName("Details");

            // Relationships
            this.HasRequired(t => t.Package)
                .WithMany(t => t.PackageDetails)
                .HasForeignKey(d => d.PackageId);

        }
    }
}
