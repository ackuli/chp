using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class EventsTypeMap : EntityTypeConfiguration<EventsType>
    {
        public EventsTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.EventsTypeId);

            // Properties
            this.Property(t => t.EventsTypeName)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("EventsType");
            this.Property(t => t.EventsTypeId).HasColumnName("EventsTypeId");
            this.Property(t => t.EventsTypeName).HasColumnName("EventsTypeName");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
        }
    }
}
