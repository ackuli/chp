using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class AdvertisMap : EntityTypeConfiguration<Advertis>
    {
        public AdvertisMap()
        {
            // Primary Key
            this.HasKey(t => t.AdvertiseId);

            // Properties
            this.Property(t => t.Name)
                .IsRequired();

            this.Property(t => t.SetBy)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Advertises");
            this.Property(t => t.AdvertiseId).HasColumnName("AdvertiseId");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.AdvertiseTypeId).HasColumnName("AdvertiseTypeId");
            this.Property(t => t.Extension).HasColumnName("Extension");
            this.Property(t => t.AdvertiseContent).HasColumnName("AdvertiseContent");
            this.Property(t => t.AdvertisePositionsId).HasColumnName("AdvertisePositionsId");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.ClientId).HasColumnName("ClientId");
            this.Property(t => t.IsDefault).HasColumnName("IsDefault");
            this.Property(t => t.SetBy).HasColumnName("SetBy");
            this.Property(t => t.SetDate).HasColumnName("SetDate");
            this.Property(t => t.Img).HasColumnName("Img");
            this.Property(t => t.LastUpdatedTime).HasColumnName("LastUpdatedTime");
            this.Property(t => t.PriorityLevel).HasColumnName("PriorityLevel");

            // Relationships
            this.HasRequired(t => t.AdvertisePosition)
                .WithMany(t => t.Advertises)
                .HasForeignKey(d => d.AdvertisePositionsId);
            this.HasRequired(t => t.AdvertiseType)
                .WithMany(t => t.Advertises)
                .HasForeignKey(d => d.AdvertiseTypeId);
            this.HasOptional(t => t.ClientInfo)
                .WithMany(t => t.Advertises)
                .HasForeignKey(d => d.ClientId);

        }
    }
}
