using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class ShiftingMap : EntityTypeConfiguration<Shifting>
    {
        public ShiftingMap()
        {
            // Primary Key
            this.HasKey(t => t.ShiftingId);

            // Properties
            this.Property(t => t.ShiftingId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ShiftingName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Shifting");
            this.Property(t => t.ShiftingId).HasColumnName("ShiftingId");
            this.Property(t => t.ShiftingName).HasColumnName("ShiftingName");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
        }
    }
}
