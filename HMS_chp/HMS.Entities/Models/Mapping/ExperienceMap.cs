using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class ExperienceMap : EntityTypeConfiguration<Experience>
    {
        public ExperienceMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.City)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Year)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Email)
                .HasMaxLength(50);

            this.Property(t => t.Phone)
                .HasMaxLength(50);

            this.Property(t => t.Narratives)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Experiences");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.Year).HasColumnName("Year");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Phone).HasColumnName("Phone");
            this.Property(t => t.Narratives).HasColumnName("Narratives");
            this.Property(t => t.IsShow).HasColumnName("IsShow");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.Setdate).HasColumnName("Setdate");
        }
    }
}
