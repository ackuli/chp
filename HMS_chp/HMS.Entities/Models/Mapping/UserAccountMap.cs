using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class UserAccountMap : EntityTypeConfiguration<UserAccount>
    {
        public UserAccountMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.UserAccountsId)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.Password)
                .IsRequired();

            this.Property(t => t.UserName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.EmailId)
                .HasMaxLength(20);

            this.Property(t => t.PhoneNo)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("UserAccounts");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserAccountsId).HasColumnName("UserAccountsId");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.RoleId).HasColumnName("RoleId");
            this.Property(t => t.UserDescription).HasColumnName("UserDescription");
            this.Property(t => t.SetDate).HasColumnName("SetDate");
            this.Property(t => t.SetBy).HasColumnName("SetBy");
            this.Property(t => t.EmailId).HasColumnName("EmailId");
            this.Property(t => t.CountryId).HasColumnName("CountryId");
            this.Property(t => t.PhoneNo).HasColumnName("PhoneNo");
            this.Property(t => t.ClientId).HasColumnName("ClientId");
            this.Property(t => t.IsTermConditionAgreed).HasColumnName("IsTermConditionAgreed");

            // Relationships
            this.HasRequired(t => t.Client)
                .WithMany(t => t.UserAccounts)
                .HasForeignKey(d => d.ClientId);
            this.HasOptional(t => t.Country)
                .WithMany(t => t.UserAccounts)
                .HasForeignKey(d => d.CountryId);
            this.HasRequired(t => t.Role)
                .WithMany(t => t.UserAccounts)
                .HasForeignKey(d => d.RoleId);

        }
    }
}
