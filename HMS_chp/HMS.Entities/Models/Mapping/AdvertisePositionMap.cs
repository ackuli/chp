using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class AdvertisePositionMap : EntityTypeConfiguration<AdvertisePosition>
    {
        public AdvertisePositionMap()
        {
            // Primary Key
            this.HasKey(t => t.AdvertisePositionsId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired();

            this.Property(t => t.TargetId)
                .HasMaxLength(100);

            this.Property(t => t.SetBy)
                .IsRequired()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("AdvertisePositions");
            this.Property(t => t.AdvertisePositionsId).HasColumnName("AdvertisePositionsId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.TargetId).HasColumnName("TargetId");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.PageId).HasColumnName("PageId");
            this.Property(t => t.Height).HasColumnName("Height");
            this.Property(t => t.Width).HasColumnName("Width");
            this.Property(t => t.Amount).HasColumnName("Amount");
            this.Property(t => t.CurrencyType).HasColumnName("CurrencyType");
            this.Property(t => t.SetBy).HasColumnName("SetBy");
            this.Property(t => t.SetDate).HasColumnName("SetDate");
            this.Property(t => t.IsDefault).HasColumnName("IsDefault");
            this.Property(t => t.LastUpdatedTime).HasColumnName("LastUpdatedTime");

            // Relationships
            this.HasOptional(t => t.CurrencyType1)
                .WithMany(t => t.AdvertisePositions)
                .HasForeignKey(d => d.CurrencyType);
            this.HasRequired(t => t.PageType)
                .WithMany(t => t.AdvertisePositions)
                .HasForeignKey(d => d.PageId);

        }
    }
}
