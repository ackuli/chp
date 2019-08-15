using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class BinaryObjectMap : EntityTypeConfiguration<BinaryObject>
    {
        public BinaryObjectMap()
        {
            // Primary Key
            this.HasKey(t => t.BinaryObjectsId);

            // Properties
            this.Property(t => t.BinaryObjectTypeName)
                .HasMaxLength(100);

            this.Property(t => t.FileName)
                .HasMaxLength(1024);

            this.Property(t => t.ContentType)
                .HasMaxLength(1024);

            // Table & Column Mappings
            this.ToTable("BinaryObjects");
            this.Property(t => t.BinaryObjectsId).HasColumnName("BinaryObjectsId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.RefObjectTypeId).HasColumnName("RefObjectTypeId");
            this.Property(t => t.RefObjectKey).HasColumnName("RefObjectKey");
            this.Property(t => t.BinaryObjectTypeName).HasColumnName("BinaryObjectTypeName");
            this.Property(t => t.ObjectCaption).HasColumnName("ObjectCaption");
            this.Property(t => t.Object).HasColumnName("Object");
            this.Property(t => t.ScriptContent).HasColumnName("ScriptContent");
            this.Property(t => t.ObjectPath).HasColumnName("ObjectPath");
            this.Property(t => t.Extension).HasColumnName("Extension");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.LastUpdatedTime).HasColumnName("LastUpdatedTime");
            this.Property(t => t.FileName).HasColumnName("FileName");
            this.Property(t => t.ContentType).HasColumnName("ContentType");
            this.Property(t => t.ObjectDescription).HasColumnName("ObjectDescription");

            // Relationships
            this.HasRequired(t => t.BinaryObjectType)
                .WithMany(t => t.BinaryObjects)
                .HasForeignKey(d => d.RefObjectTypeId);

        }
    }
}
