using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class RecentSearchMap : EntityTypeConfiguration<RecentSearch>
    {
        public RecentSearchMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("RecentSearches");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.SessionKey).HasColumnName("SessionKey");
            this.Property(t => t.From).HasColumnName("From");
            this.Property(t => t.Duration).HasColumnName("Duration");
            this.Property(t => t.PepolePerRoom).HasColumnName("PepolePerRoom");
            this.Property(t => t.HotelClass).HasColumnName("HotelClass");
            this.Property(t => t.SetDate).HasColumnName("SetDate");
        }
    }
}
