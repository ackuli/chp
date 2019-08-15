using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class ContactUMap : EntityTypeConfiguration<ContactU>
    {
        public ContactUMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(128);

            this.Property(t => t.FirstName)
                .HasMaxLength(128);

            this.Property(t => t.LastName)
                .HasMaxLength(128);

            this.Property(t => t.Address)
                .HasMaxLength(512);

            this.Property(t => t.Country)
                .HasMaxLength(128);

            this.Property(t => t.ContactNumber)
                .HasMaxLength(128);

            this.Property(t => t.Email)
                .HasMaxLength(128);

            this.Property(t => t.Subject)
                .IsRequired()
                .HasMaxLength(512);

            this.Property(t => t.Message)
                .IsRequired();

            this.Property(t => t.Captcha)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ContactUs");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Country).HasColumnName("Country");
            this.Property(t => t.ContactNumber).HasColumnName("ContactNumber");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Subject).HasColumnName("Subject");
            this.Property(t => t.Message).HasColumnName("Message");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.LastUpdateTime).HasColumnName("LastUpdateTime");
            this.Property(t => t.Captcha).HasColumnName("Captcha");
        }
    }
}
