using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class PageInfoDetailMap : EntityTypeConfiguration<PageInfoDetail>
    {
        public PageInfoDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.PageInfoDetailsId);

            // Properties
            this.Property(t => t.PageInfoDetailsId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("PageInfoDetails");
            this.Property(t => t.PageInfoDetailsId).HasColumnName("PageInfoDetailsId");
            this.Property(t => t.PageInfoId).HasColumnName("PageInfoId");
            this.Property(t => t.PageSubHeading).HasColumnName("PageSubHeading");
            this.Property(t => t.PageInfoDetails).HasColumnName("PageInfoDetails");
        }
    }
}
