using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class RightssMap : EntityTypeConfiguration<Rightss>
    {
        public RightssMap()
        {
            // Primary Key
            this.HasKey(t => t.RightsId);

            // Properties
            this.Property(t => t.RightsId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.RightsName)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.IsActive)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Rightss");
            this.Property(t => t.RightsId).HasColumnName("RightsId");
            this.Property(t => t.RightsName).HasColumnName("RightsName");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
        }
    }
}
