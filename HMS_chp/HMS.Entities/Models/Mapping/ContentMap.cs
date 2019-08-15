using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class ContentMap : EntityTypeConfiguration<Content>
    {
        public ContentMap()
        {
            // Primary Key
            this.HasKey(t => t.ContentId);

            // Properties
            this.Property(t => t.ContentName)
                .HasMaxLength(500);

            this.Property(t => t.ContentURL)
                .HasMaxLength(500);

            this.Property(t => t.ContentHeader)
                .HasMaxLength(500);

            this.Property(t => t.ContentSubHeader)
                .HasMaxLength(500);

            this.Property(t => t.VedioContent)
                .HasMaxLength(5000);

            this.Property(t => t.ContentExtention)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Content");
            this.Property(t => t.ContentId).HasColumnName("ContentId");
            this.Property(t => t.ContentNameId).HasColumnName("ContentNameId");
            this.Property(t => t.ContentName).HasColumnName("ContentName");
            this.Property(t => t.ContentURL).HasColumnName("ContentURL");
            this.Property(t => t.ContentHeader).HasColumnName("ContentHeader");
            this.Property(t => t.ContentSubHeader).HasColumnName("ContentSubHeader");
            this.Property(t => t.ContentTypeId).HasColumnName("ContentTypeId");
            this.Property(t => t.TextContent).HasColumnName("TextContent");
            this.Property(t => t.ImageContent).HasColumnName("ImageContent");
            this.Property(t => t.VedioContent).HasColumnName("VedioContent");
            this.Property(t => t.DocumentContent).HasColumnName("DocumentContent");
            this.Property(t => t.ContentExtention).HasColumnName("ContentExtention");
        }
    }
}
