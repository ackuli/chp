using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class PriceTypeMap : EntityTypeConfiguration<PriceType>
    {
        public PriceTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.PriceTypeId);

            // Properties
            this.Property(t => t.PriceTypeName)
                .HasMaxLength(100);

            this.Property(t => t.SetBy)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("PriceType");
            this.Property(t => t.PriceTypeId).HasColumnName("PriceTypeId");
            this.Property(t => t.PriceTypeName).HasColumnName("PriceTypeName");
            this.Property(t => t.SetDate).HasColumnName("SetDate");
            this.Property(t => t.SetBy).HasColumnName("SetBy");
        }
    }
}
