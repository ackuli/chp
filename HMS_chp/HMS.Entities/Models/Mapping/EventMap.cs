using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class EventMap : EntityTypeConfiguration<Event>
    {
        public EventMap()
        {
            // Primary Key
            this.HasKey(t => t.EventsId);

            // Properties
            this.Property(t => t.EventsTitle)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Language)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Time)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Venue)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Address)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.PostCode)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.OrgWebsite)
                .HasMaxLength(150);

            this.Property(t => t.OrgPhone)
                .HasMaxLength(150);

            this.Property(t => t.OrgEmail)
                .HasMaxLength(150);

            this.Property(t => t.OrgContactAddress)
                .HasMaxLength(150);

            this.Property(t => t.Documents)
                .HasMaxLength(100);

            this.Property(t => t.Logo)
                .HasMaxLength(100);

            this.Property(t => t.YourName)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.YourOrganisation)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.YourPhone)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.YourEmail)
                .IsRequired()
                .HasMaxLength(150);

            this.Property(t => t.SetBy)
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Events");
            this.Property(t => t.EventsId).HasColumnName("EventsId");
            this.Property(t => t.EventsTitle).HasColumnName("EventsTitle");
            this.Property(t => t.EventDescription).HasColumnName("EventDescription");
            this.Property(t => t.Language).HasColumnName("Language");
            this.Property(t => t.EventsTypeId).HasColumnName("EventsTypeId");
            this.Property(t => t.EventsDate).HasColumnName("EventsDate");
            this.Property(t => t.StartDate).HasColumnName("StartDate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");
            this.Property(t => t.Time).HasColumnName("Time");
            this.Property(t => t.Venue).HasColumnName("Venue");
            this.Property(t => t.Address).HasColumnName("Address");
            this.Property(t => t.PostCode).HasColumnName("PostCode");
            this.Property(t => t.OrgWebsite).HasColumnName("OrgWebsite");
            this.Property(t => t.OrgPhone).HasColumnName("OrgPhone");
            this.Property(t => t.OrgEmail).HasColumnName("OrgEmail");
            this.Property(t => t.OrgContactAddress).HasColumnName("OrgContactAddress");
            this.Property(t => t.Documents).HasColumnName("Documents");
            this.Property(t => t.Logo).HasColumnName("Logo");
            this.Property(t => t.YourName).HasColumnName("YourName");
            this.Property(t => t.YourOrganisation).HasColumnName("YourOrganisation");
            this.Property(t => t.YourPhone).HasColumnName("YourPhone");
            this.Property(t => t.YourEmail).HasColumnName("YourEmail");
            this.Property(t => t.SetBy).HasColumnName("SetBy");
            this.Property(t => t.IsVisible).HasColumnName("IsVisible");
            this.Property(t => t.IsArchive).HasColumnName("IsArchive");
            this.Property(t => t.IsDefault).HasColumnName("IsDefault");
            this.Property(t => t.IsAcceptedPrivacyCookiePolicy).HasColumnName("IsAcceptedPrivacyCookiePolicy");
            this.Property(t => t.IsAcceptedTermsConditions).HasColumnName("IsAcceptedTermsConditions");

            // Relationships
            this.HasRequired(t => t.EventsType)
                .WithMany(t => t.Events)
                .HasForeignKey(d => d.EventsTypeId);

        }
    }
}
