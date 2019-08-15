using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class ClientInformationMap : EntityTypeConfiguration<ClientInformation>
    {
        public ClientInformationMap()
        {
            // Primary Key
            this.HasKey(t => t.ClientInfoId);

            // Properties
            this.Property(t => t.Address)
                .HasMaxLength(500);

            this.Property(t => t.Tellandline)
                .HasMaxLength(16);

            this.Property(t => t.TelMobile)
                .HasMaxLength(16);

            this.Property(t => t.Email)
                .HasMaxLength(128);

            this.Property(t => t.Website)
                .HasMaxLength(250);

            this.Property(t => t.YearEstablished)
                .HasMaxLength(6);

            this.Property(t => t.Approvedfor)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.Remarks)
                .HasMaxLength(500);

            this.Property(t => t.SetBy)
                .IsRequired()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("ClientInformation");
            this.Property(t => t.ClientInfoId).HasColumnName("ClientInfoId");
            this.Property(t => t.ClientId).HasColumnName("ClientId");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Tellandline).HasColumnName("Tellandline");
            this.Property(t => t.TelMobile).HasColumnName("TelMobile");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Website).HasColumnName("Website");
            this.Property(t => t.YearEstablished).HasColumnName("YearEstablished");
            this.Property(t => t.IsApprovedbySaudiHajjMinistry).HasColumnName("IsApprovedbySaudiHajjMinistry");
            this.Property(t => t.MinistryApprovalNumber).HasColumnName("MinistryApprovalNumber");
            this.Property(t => t.Approvedfor).HasColumnName("Approvedfor");
            this.Property(t => t.ATOLApproved).HasColumnName("ATOLApproved");
            this.Property(t => t.ATOLLicense).HasColumnName("ATOLLicense");
            this.Property(t => t.IATANo).HasColumnName("IATANo");
            this.Property(t => t.CompanyRegistrationNumber).HasColumnName("CompanyRegistrationNumber");
            this.Property(t => t.Remarks).HasColumnName("Remarks");
            this.Property(t => t.SetBy).HasColumnName("SetBy");
            this.Property(t => t.SetDate).HasColumnName("SetDate");
            this.Property(t => t.LastUpdateDate).HasColumnName("LastUpdateDate");

            // Relationships
            this.HasRequired(t => t.Client)
                .WithMany(t => t.ClientInformations)
                .HasForeignKey(d => d.ClientId);

        }
    }
}
