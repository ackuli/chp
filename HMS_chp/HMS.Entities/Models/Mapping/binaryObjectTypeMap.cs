using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class BinaryObjectTypeMap : EntityTypeConfiguration<BinaryObjectType>
    {
        public BinaryObjectTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.BinaryObjectsTypeId);

            // Properties
            this.Property(t => t.ObjectTypeSource)
                .HasMaxLength(100);

            this.Property(t => t.Name)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("BinaryObjectTypes");
            this.Property(t => t.BinaryObjectsTypeId).HasColumnName("BinaryObjectsTypeId");
            this.Property(t => t.ObjectTypeSource).HasColumnName("ObjectTypeSource");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
