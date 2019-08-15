using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class PackageDisplayTypeMap : EntityTypeConfiguration<PackageDisplayType>
    {
        public PackageDisplayTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.PackageDisplayTypeId);

            // Properties
            this.Property(t => t.PackageDisplayTypeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .HasMaxLength(300);

            this.Property(t => t.Description)
                .HasMaxLength(300);

            // Table & Column Mappings
            this.ToTable("PackageDisplayType");
            this.Property(t => t.PackageDisplayTypeId).HasColumnName("PackageDisplayTypeId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
