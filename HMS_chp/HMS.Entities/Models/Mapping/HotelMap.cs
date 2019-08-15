using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class HotelMap : EntityTypeConfiguration<Hotel>
    {
        public HotelMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Star)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Hotels");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Star).HasColumnName("Star");
            this.Property(t => t.DistanceFromHaram).HasColumnName("DistanceFromHaram");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.SetDate).HasColumnName("SetDate");
        }
    }
}
