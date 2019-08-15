using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HMS.Entities.Models.Mapping
{
    public class PackagesInfoMap : EntityTypeConfiguration<PackagesInfo>
    {
        public PackagesInfoMap()
        {
            // Primary Key
            this.HasKey(t => t.PackageId);

            // Properties
            this.Property(t => t.PackageName)
                .IsRequired()
                .HasMaxLength(250);

            this.Property(t => t.HotelNameMakka)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.HotelNameMadinah)
                .IsRequired()
                .HasMaxLength(500);

            this.Property(t => t.FlightsDepart)
                .HasMaxLength(25);

            this.Property(t => t.FlightsReturn)
                .HasMaxLength(25);

            this.Property(t => t.Remarks)
                .HasMaxLength(500);

            this.Property(t => t.SetBy)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.PackageDisplayInput)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("PackagesInfo");
            this.Property(t => t.PackageId).HasColumnName("PackageId");
            this.Property(t => t.PackageName).HasColumnName("PackageName");
            this.Property(t => t.StatusId).HasColumnName("StatusId");
            this.Property(t => t.Duration).HasColumnName("Duration");
            this.Property(t => t.ClientId).HasColumnName("ClientId");
            this.Property(t => t.PricePerPerson).HasColumnName("PricePerPerson");
            this.Property(t => t.PriceTypeId).HasColumnName("PriceTypeId");
            this.Property(t => t.DistanceUnitId).HasColumnName("DistanceUnitId");
            this.Property(t => t.PackageTypeId).HasColumnName("PackageTypeId");
            this.Property(t => t.HotelNameMakka).HasColumnName("HotelNameMakka");
            this.Property(t => t.HotelDistanceMakka).HasColumnName("HotelDistanceMakka");
            this.Property(t => t.HotelNameMadinah).HasColumnName("HotelNameMadinah");
            this.Property(t => t.HotelDistanceMadinah).HasColumnName("HotelDistanceMadinah");
            this.Property(t => t.PeoplePerRooms).HasColumnName("PeoplePerRooms");
            this.Property(t => t.IsFlightDepRetDateExist).HasColumnName("IsFlightDepRetDateExist");
            this.Property(t => t.FlightsDepart).HasColumnName("FlightsDepart");
            this.Property(t => t.FlightsReturn).HasColumnName("FlightsReturn");
            this.Property(t => t.Remarks).HasColumnName("Remarks");
            this.Property(t => t.ShiftingId).HasColumnName("ShiftingId");
            this.Property(t => t.SetBy).HasColumnName("SetBy");
            this.Property(t => t.LastUpdateDate).HasColumnName("LastUpdateDate");
            this.Property(t => t.HotelClassId).HasColumnName("HotelClassId");
            this.Property(t => t.PackagesubscribeId).HasColumnName("PackagesubscribeId");
            this.Property(t => t.PackageDisplayTypeId).HasColumnName("PackageDisplayTypeId");
            this.Property(t => t.PackageDisplayInput).HasColumnName("PackageDisplayInput");
            this.Property(t => t.PackageCreationdate).HasColumnName("PackageCreationdate");
            this.Property(t => t.Startdate).HasColumnName("Startdate");
            this.Property(t => t.EndDate).HasColumnName("EndDate");

            // Relationships
            this.HasRequired(t => t.Client)
                .WithMany(t => t.PackagesInfoes)
                .HasForeignKey(d => d.ClientId);
            this.HasRequired(t => t.CurrencyType)
                .WithMany(t => t.PackagesInfoes)
                .HasForeignKey(d => d.PriceTypeId);
            this.HasRequired(t => t.DistanceUnit)
                .WithMany(t => t.PackagesInfoes)
                .HasForeignKey(d => d.DistanceUnitId);
            this.HasRequired(t => t.Duration1)
                .WithMany(t => t.PackagesInfoes)
                .HasForeignKey(d => d.Duration);
            this.HasRequired(t => t.Hotel)
                .WithMany(t => t.PackagesInfoes)
                .HasForeignKey(d => d.HotelClassId);
            this.HasRequired(t => t.PackageDisplayType)
                .WithMany(t => t.PackagesInfoes)
                .HasForeignKey(d => d.PackageDisplayTypeId);
            this.HasRequired(t => t.PackageSubscribe)
                .WithMany(t => t.PackagesInfoes)
                .HasForeignKey(d => d.PackagesubscribeId);
            this.HasRequired(t => t.PackageType)
                .WithMany(t => t.PackagesInfoes)
                .HasForeignKey(d => d.PackageTypeId);
            this.HasRequired(t => t.PeoplePerRoom)
                .WithMany(t => t.PackagesInfoes)
                .HasForeignKey(d => d.PeoplePerRooms);
            this.HasRequired(t => t.PriceType)
                .WithMany(t => t.PackagesInfoes)
                .HasForeignKey(d => d.PriceTypeId);
            this.HasRequired(t => t.Shifting)
                .WithMany(t => t.PackagesInfoes)
                .HasForeignKey(d => d.ShiftingId);
            this.HasRequired(t => t.Statuss)
                .WithMany(t => t.PackagesInfoes)
                .HasForeignKey(d => d.StatusId);

        }
    }
}
