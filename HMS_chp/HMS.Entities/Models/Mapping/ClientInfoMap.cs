using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class ClientInfoMap : EntityTypeConfiguration<ClientInfo>
    {
        public ClientInfoMap()
        {
            // Primary Key
            this.HasKey(t => t.ClientId);

            // Properties
            this.Property(t => t.ClientIdentityId)
                .HasMaxLength(10);

            this.Property(t => t.ClientName)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.SetBy)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.ContactNumber)
                .HasMaxLength(20);

            this.Property(t => t.EmailAddress)
                .HasMaxLength(15);

            this.Property(t => t.Img)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ClientInfo");
            this.Property(t => t.ClientId).HasColumnName("ClientId");
            this.Property(t => t.ClientIdentityId).HasColumnName("ClientIdentityId");
            this.Property(t => t.ClientName).HasColumnName("ClientName");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Amount).HasColumnName("Amount");
            this.Property(t => t.Setdate).HasColumnName("Setdate");
            this.Property(t => t.LastUpdatedTime).HasColumnName("LastUpdatedTime");
            this.Property(t => t.SetBy).HasColumnName("SetBy");
            this.Property(t => t.ContactNumber).HasColumnName("ContactNumber");
            this.Property(t => t.EmailAddress).HasColumnName("EmailAddress");
            this.Property(t => t.Img).HasColumnName("Img");
            this.Property(t => t.CurrencyType).HasColumnName("CurrencyType");
            this.Property(t => t.IsActive).HasColumnName("IsActive");
            this.Property(t => t.CountryId).HasColumnName("CountryId");

            // Relationships
            this.HasOptional(t => t.Country)
                .WithMany(t => t.ClientInfoes)
                .HasForeignKey(d => d.CountryId);
            this.HasRequired(t => t.CurrencyType1)
                .WithMany(t => t.ClientInfoes)
                .HasForeignKey(d => d.CurrencyType);

        }
    }
}
