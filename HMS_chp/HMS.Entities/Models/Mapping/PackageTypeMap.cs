using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class PackageTypeMap : EntityTypeConfiguration<PackageType>
    {
        public PackageTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.PackageTypeId);

            // Properties
            this.Property(t => t.PackageTypeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.PackageTypename)
                .HasMaxLength(150);

            this.Property(t => t.SetBy)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("PackageType");
            this.Property(t => t.PackageTypeId).HasColumnName("PackageTypeId");
            this.Property(t => t.PackageTypename).HasColumnName("PackageTypename");
            this.Property(t => t.SetDate).HasColumnName("SetDate");
            this.Property(t => t.SetBy).HasColumnName("SetBy");
        }
    }
}
