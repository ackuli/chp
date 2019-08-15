using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class HotelDetailMap : EntityTypeConfiguration<HotelDetail>
    {
        public HotelDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("HotelDetails");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.HotelId).HasColumnName("HotelId");
            this.Property(t => t.WifiInRooms).HasColumnName("WifiInRooms");
            this.Property(t => t.WifiInLobby).HasColumnName("WifiInLobby");
            this.Property(t => t.SatelliteTV).HasColumnName("SatelliteTV");
            this.Property(t => t.Restaurant).HasColumnName("Restaurant");
            this.Property(t => t.LaundryService).HasColumnName("LaundryService");
            this.Property(t => t.SafeDepositBox).HasColumnName("SafeDepositBox");
            this.Property(t => t.WheelchairAccess).HasColumnName("WheelchairAccess");
            this.Property(t => t.AC).HasColumnName("AC");
            this.Property(t => t.RoomService).HasColumnName("RoomService");
            this.Property(t => t.Lift).HasColumnName("Lift");
            this.Property(t => t.NonSmokingRooms).HasColumnName("NonSmokingRooms");
            this.Property(t => t.Kitchenette).HasColumnName("Kitchenette");
            this.Property(t => t.MiniBarFridge).HasColumnName("MiniBarFridge");

            // Relationships
            this.HasRequired(t => t.Hotel)
                .WithMany(t => t.HotelDetails)
                .HasForeignKey(d => d.HotelId);

        }
    }
}
