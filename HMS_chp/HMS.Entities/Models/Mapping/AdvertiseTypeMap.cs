using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class AdvertiseTypeMap : EntityTypeConfiguration<AdvertiseType>
    {
        public AdvertiseTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.AdvertiseTypeId);

            // Properties
            this.Property(t => t.AdvertiseTypeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Name)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("AdvertiseTypes");
            this.Property(t => t.AdvertiseTypeId).HasColumnName("AdvertiseTypeId");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
