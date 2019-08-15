using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class ScholareMap : EntityTypeConfiguration<Scholare>
    {
        public ScholareMap()
        {
            // Primary Key
            this.HasKey(t => t.ScholarId);

            // Properties
            this.Property(t => t.ScholarName)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Scholares");
            this.Property(t => t.ScholarId).HasColumnName("ScholarId");
            this.Property(t => t.ScholarName).HasColumnName("ScholarName");
            this.Property(t => t.Scholarbiography).HasColumnName("Scholarbiography");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.Logdate).HasColumnName("Logdate");
        }
    }
}
