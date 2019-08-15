using HMS.Entities.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities.Models
{
    public partial class EventMetaData
    {
        [Display(Name = "Event Title")]
        [Required(ErrorMessage = "The Event Title Required")]
        [StringLength(50)]
        public string EventsTitle { get; set; }

        [Display(Name = "Language")]
        [StringLength(100)]
        [Required(ErrorMessage = "Language")]
        public string Language { get; set; }

        [Display(Name = "Event Type")]
        [Required(ErrorMessage = "The Event Type Required")]
        public int EventsTypeId { get; set; }

        [Required(ErrorMessage = "The Start Date Required")]
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
               ApplyFormatInEditMode = true)]
       // [DataType(DataType.Date)]
        public Nullable<System.DateTime> StartDate { get; set; }

        [Required(ErrorMessage = "The Events Date Required")]
      //  [Display(Name = "Events Date")]
        //[DataType(DataType.Date)]
        [DataType(DataType.Date)]
        public System.DateTime EventsDate { get; set; }

        [Required(ErrorMessage = "The End Date Required")]
        [Display(Name = "End Date")]
       // [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
           ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> EndDate { get; set; }

        [Display(Name = "Event Time")]
        [Required(ErrorMessage = "The Event Time Required")]
        [StringLength(50)]
        public string Time { get; set; }

        [Display(Name = "Event Venue")]
        [Required(ErrorMessage = "The Event Venue Required")]
        [StringLength(50)]
        public string Venue { get; set; }

        [Display(Name = "Venue Address")]
        [Required(ErrorMessage = "The Venue Address Required")]
        public string Address { get; set; }

        [Display(Name = "Post Code")]
        [Required(ErrorMessage = "The Post Code Required")]

        [StringLength(9)]
        public string PostCode { get; set; }

        [Display(Name = "Your Name")]
        [Required(ErrorMessage = "The Your Name Required")]
        [StringLength(20)]
        public string YourName { get; set; }

        [Display(Name = "Your Organisation Name")]
        [Required(ErrorMessage = "The Your Organisation Name Required")]
        public string YourOrganisation { get; set; }

        [Display(Name = "Your Phone No")]
        [StringLength(12)]
        [Required(ErrorMessage = "The Your Phone No Required")]
        public string YourPhone { get; set; }

        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        [Required(ErrorMessage = "The Email Address is required.")]
        [StringLength(100)]
        public string YourEmail { get; set; }

        [Display(Name = "Website")]
        public string OrgWebsite { get; set; }
        [Display(Name = "Phone")]
        public string OrgPhone { get; set; }
        [Display(Name = "Email Address")]
        public string OrgEmail { get; set; }
        [Display(Name = "Contact Address")]
        public string OrgContactAddress { get; set; }

        //[Range(typeof(bool), "true", "true", ErrorMessage = "You gotta tick the box!")]
        ////[MustBeTrue(ErrorMessage = "You gotta tick the box!")]
        //public bool IsAcceptedPrivacyCookiePolicy { get; set; }
        // [Range(typeof(bool), "true", "true", ErrorMessage = "You gotta tick the box!")]
        //public bool IsAcceptedTermsConditions { get; set; }
    }
}
