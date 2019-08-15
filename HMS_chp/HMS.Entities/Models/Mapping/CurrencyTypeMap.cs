using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class CurrencyTypeMap : EntityTypeConfiguration<CurrencyType>
    {
        public CurrencyTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.CurrencyTypeId);

            // Properties
            this.Property(t => t.CurrencyTypeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.CurrencyName)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("CurrencyType");
            this.Property(t => t.CurrencyTypeId).HasColumnName("CurrencyTypeId");
            this.Property(t => t.CurrencyName).HasColumnName("CurrencyName");
        }
    }
}
