using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class RoleRightssMap : EntityTypeConfiguration<RoleRightss>
    {
        public RoleRightssMap()
        {
            // Primary Key
            this.HasKey(t => t.RoleRightsId);

            // Properties
            this.Property(t => t.SetBy)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("RoleRightss");
            this.Property(t => t.RoleRightsId).HasColumnName("RoleRightsId");
            this.Property(t => t.RoleId).HasColumnName("RoleId");
            this.Property(t => t.RightId).HasColumnName("RightId");
            this.Property(t => t.SetBy).HasColumnName("SetBy");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.ClientId).HasColumnName("ClientId");

            // Relationships
            this.HasRequired(t => t.Client)
                .WithMany(t => t.RoleRightsses)
                .HasForeignKey(d => d.ClientId);
            this.HasOptional(t => t.Rightss)
                .WithMany(t => t.RoleRightsses)
                .HasForeignKey(d => d.RightId);
            this.HasOptional(t => t.Role)
                .WithMany(t => t.RoleRightsses)
                .HasForeignKey(d => d.RoleId);

        }
    }
}
