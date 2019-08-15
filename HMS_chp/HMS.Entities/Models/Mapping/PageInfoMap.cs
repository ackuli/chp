using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class PageInfoMap : EntityTypeConfiguration<PageInfo>
    {
        public PageInfoMap()
        {
            // Primary Key
            this.HasKey(t => t.PageInfoId);

            // Properties
            this.Property(t => t.PageInfoId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.PageName)
                .IsRequired();

            this.Property(t => t.PageMainHeading)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("PageInfo");
            this.Property(t => t.PageInfoId).HasColumnName("PageInfoId");
            this.Property(t => t.PageName).HasColumnName("PageName");
            this.Property(t => t.PageMainHeading).HasColumnName("PageMainHeading");
            this.Property(t => t.PageMainHeadingDetails).HasColumnName("PageMainHeadingDetails");
            this.Property(t => t.PageURL).HasColumnName("PageURL");
            this.Property(t => t.PageDownload).HasColumnName("PageDownload");
            this.Property(t => t.PageView).HasColumnName("PageView");
        }
    }
}
