using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities.Models
{
    public partial class PackagesInfoMetadata
    {

        [Display(Name = "Package Name")]
        [Required(ErrorMessage = "The Package Name field is required.")]
        [StringLength(250)]
        public string PackageName { get; set; }

        [Display(Name = "Duration")]
        [Required(ErrorMessage = "The Duration is required.")]
        public int Duration { get; set; }

        [Display(Name = "Package Type")]
        [Required(ErrorMessage = "The Package Type is required.")]
        public int PackageTypeId { get; set; }

        [Display(Name = "Hotel Name [Makkah]")]
        [StringLength(500)]
        [Required(ErrorMessage = "The Hotel Name Makka Type is required.")]
        public string HotelNameMakka { get; set; }

        [Display(Name = "Hotel Distance [Makkah] from The Masjid al-Ḥarām")]
        [Range(typeof(decimal), "0", "1000.00")]
        [Required(ErrorMessage = "The Hotel Distance Makka is required.")]
        public decimal HotelDistanceMakka { get; set; }

        [Display(Name = "Hotel Name [Madinah]")]
        [StringLength(500)]
        [Required(ErrorMessage = "The Hotel Name Madinah is required.")]
        public string HotelNameMadinah { get; set; }

        [Display(Name = "Hotel Distance [Madinah] from Masjid-an Nawabi")]
        [Required(ErrorMessage = "The Hotel Distance Madinah is required.")]

        [Range(typeof(decimal), "0", "1000.00")]
        public decimal HotelDistanceMadinah { get; set; }

        [Display(Name = "Occupancy")]
        [Required(ErrorMessage = "The Occupancy is required.")]
        public int PeoplePerRooms { get; set; }

        [Display(Name = "Flights Depart")]
        [Required(ErrorMessage = "The Flights Depart required.")]
        [StringLength(25)]
        public string FlightsDepart { get; set; }

        [Display(Name = "Flights Return")]
        [Required(ErrorMessage = "The Flights Return is required.")]
        [StringLength(25)]
        public string FlightsReturn { get; set; }
        [Display(Name = "Shifting")]
        [Required(ErrorMessage = "The Shifting is required.")]
        public int ShiftingId { get; set; }
        [Display(Name = "Hotel Class")]
        [Required(ErrorMessage = "The Hotel Class is required.")]
        public int HotelClassId { get; set; }
        [Display(Name = "Price Per Person")]
        [Required(ErrorMessage = "The Price Per Person is required.")]
        public decimal PricePerPerson { get; set; }

        [Display(Name = "The comparehajjpackages.com offers three different types of listing services. Please select the listing service(s) you are interested to subscribe: ")]
        [Required(ErrorMessage = "The Package subscribe is required.")]
        public int PackagesubscribeId { get; set; }
    }
}
