using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class DurationMap : EntityTypeConfiguration<Duration>
    {
        public DurationMap()
        {
            // Primary Key
            this.HasKey(t => t.DurationId);

            // Properties
            this.Property(t => t.DuratioName)
                .HasMaxLength(50);

            this.Property(t => t.SetBy)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Duration");
            this.Property(t => t.DurationId).HasColumnName("DurationId");
            this.Property(t => t.DuratioName).HasColumnName("DuratioName");
            this.Property(t => t.SetDate).HasColumnName("SetDate");
            this.Property(t => t.SetBy).HasColumnName("SetBy");
        }
    }
}
