using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class ClientMap : EntityTypeConfiguration<Client>
    {
        public ClientMap()
        {
            // Primary Key
            this.HasKey(t => t.ClientId);

            // Properties
            this.Property(t => t.ClientId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.ClientName)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.SetBy)
                .IsRequired()
                .HasMaxLength(10);

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

            this.Property(t => t.HajjApprovalLicienceNumberNo)
                .HasMaxLength(50);

            this.Property(t => t.UmarhApprovalLicienceNumberNo)
                .HasMaxLength(50);

            this.Property(t => t.Approvedfor)
                .IsFixedLength()
                .HasMaxLength(10);

            this.Property(t => t.Remarks)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Client");
            this.Property(t => t.ClientId).HasColumnName("ClientId");
            this.Property(t => t.ClientName).HasColumnName("ClientName");
            this.Property(t => t.SetBy).HasColumnName("SetBy");
            this.Property(t => t.Setdate).HasColumnName("Setdate");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.Tellandline).HasColumnName("Tellandline");
            this.Property(t => t.TelMobile).HasColumnName("TelMobile");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Website).HasColumnName("Website");
            this.Property(t => t.YearEstablished).HasColumnName("YearEstablished");
            this.Property(t => t.IsApprovedbySaudiHajjMinistry).HasColumnName("IsApprovedbySaudiHajjMinistry");
            this.Property(t => t.IsHajjApproval).HasColumnName("IsHajjApproval");
            this.Property(t => t.HajjApprovalLicienceNumberNo).HasColumnName("HajjApprovalLicienceNumberNo");
            this.Property(t => t.IsUmarhApproval).HasColumnName("IsUmarhApproval");
            this.Property(t => t.UmarhApprovalLicienceNumberNo).HasColumnName("UmarhApprovalLicienceNumberNo");
            this.Property(t => t.MinistryApprovalNumber).HasColumnName("MinistryApprovalNumber");
            this.Property(t => t.Approvedfor).HasColumnName("Approvedfor");
            this.Property(t => t.ATOLApproved).HasColumnName("ATOLApproved");
            this.Property(t => t.ATOLLicense).HasColumnName("ATOLLicense");
            this.Property(t => t.IATANo).HasColumnName("IATANo");
            this.Property(t => t.CompanyRegistrationNumber).HasColumnName("CompanyRegistrationNumber");
            this.Property(t => t.Remarks).HasColumnName("Remarks");
            this.Property(t => t.LastUpdateDate).HasColumnName("LastUpdateDate");
        }
    }
}
