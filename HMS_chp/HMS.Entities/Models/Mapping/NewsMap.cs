using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class NewsMap : EntityTypeConfiguration<News>
    {
        public NewsMap()
        {
            // Primary Key
            this.HasKey(t => t.NewsId);

            // Properties
            this.Property(t => t.NewsTitle)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.Description)
                .IsRequired();

            this.Property(t => t.Source)
                .IsRequired()
                .HasMaxLength(150);

            // Table & Column Mappings
            this.ToTable("News");
            this.Property(t => t.NewsId).HasColumnName("NewsId");
            this.Property(t => t.NewsTitle).HasColumnName("NewsTitle");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.NewsLink).HasColumnName("NewsLink");
            this.Property(t => t.Source).HasColumnName("Source");
            this.Property(t => t.PublishDate).HasColumnName("PublishDate");
            this.Property(t => t.Img).HasColumnName("Img");
            this.Property(t => t.IsArchive).HasColumnName("IsArchive");
            this.Property(t => t.LastUpdateTime).HasColumnName("LastUpdateTime");
            this.Property(t => t.IsVisible).HasColumnName("IsVisible");
            this.Property(t => t.IsDefault).HasColumnName("IsDefault");
            this.Property(t => t.SourceDate).HasColumnName("SourceDate");
        }
    }
}
