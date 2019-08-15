using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class DistanceUnitMap : EntityTypeConfiguration<DistanceUnit>
    {
        public DistanceUnitMap()
        {
            // Primary Key
            this.HasKey(t => t.DistanceUnitId);

            // Properties
            this.Property(t => t.DistanceUnitId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.DistanceUnitName)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.DistanceDescription)
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("DistanceUnit");
            this.Property(t => t.DistanceUnitId).HasColumnName("DistanceUnitId");
            this.Property(t => t.DistanceUnitName).HasColumnName("DistanceUnitName");
            this.Property(t => t.DistanceDescription).HasColumnName("DistanceDescription");
        }
    }
}
