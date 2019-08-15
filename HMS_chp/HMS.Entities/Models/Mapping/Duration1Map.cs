using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class Duration1Map : EntityTypeConfiguration<Duration1>
    {
        public Duration1Map()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.TotalDuration)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Durations");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.TotalDuration).HasColumnName("TotalDuration");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.SetDate).HasColumnName("SetDate");
            this.Property(t => t.SetBy).HasColumnName("SetBy");
        }
    }
}
