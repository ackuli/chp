using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class PackageSubscribeMap : EntityTypeConfiguration<PackageSubscribe>
    {
        public PackageSubscribeMap()
        {
            // Primary Key
            this.HasKey(t => t.PackagesubscribeId);

            // Properties
            this.Property(t => t.PackagesubscribeId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.PackageSubscribeName)
                .IsRequired()
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("PackageSubscribe");
            this.Property(t => t.PackagesubscribeId).HasColumnName("PackagesubscribeId");
            this.Property(t => t.PackageSubscribeName).HasColumnName("PackageSubscribeName");
            this.Property(t => t.SetDate).HasColumnName("SetDate");
        }
    }
}
