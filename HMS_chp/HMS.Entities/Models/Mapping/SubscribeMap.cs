using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class SubscribeMap : EntityTypeConfiguration<Subscribe>
    {
        public SubscribeMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Email)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Subscribes");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.SetDate).HasColumnName("SetDate");
        }
    }
}
