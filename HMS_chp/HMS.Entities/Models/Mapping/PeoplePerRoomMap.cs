using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class PeoplePerRoomMap : EntityTypeConfiguration<PeoplePerRoom>
    {
        public PeoplePerRoomMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.RoomCapacity)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("PeoplePerRooms");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.RoomCapacity).HasColumnName("RoomCapacity");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.SetDate).HasColumnName("SetDate");
            this.Property(t => t.SetBy).HasColumnName("SetBy");
        }
    }
}
