using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities.Models
{
    public class ClientMetaData
    {

        [Display(Name = "Agent Name")]
        [Required(ErrorMessage = "The Agent Name field is required.")]
        [StringLength(500)]
        public string ClientName { get; set; }
        [StringLength(500)]
        public string Address { get; set; }
        [StringLength(16)]
        [Display(Name = "Tel [landline]")]
        public string Tellandline { get; set; }
        [StringLength(16)]
        [Display(Name = "Tel [Mobile]")]
        
        public string TelMobile { get; set; }
        [StringLength(128)]
        [EmailAddress]
        public string Email { get; set; }
        [StringLength(250)]
        public string Website { get; set; }
        [StringLength(6)]
        [Display(Name = "Year Established")]

        public string YearEstablished { get; set; }
        [Display(Name = "Approved by the Saudi Hajj Ministry")]
        
        public bool IsApprovedbySaudiHajjMinistry { get; set; }

        [Display(Name = "Ministry Approval Number")]
        [Range(typeof(decimal), "0", "9999")]
        public Nullable<decimal> MinistryApprovalNumber { get; set; }
        [Display(Name = "Approved for")]

        [StringLength(10)]
        public string Approvedfor { get; set; }
        [Display(Name = "ATOL Approved")]
        public bool ATOLApproved { get; set; }
        [Range(typeof(decimal), "0", "9999")]
        [Display(Name = "ATOL License")]
        public Nullable<decimal> ATOLLicense { get; set; }
        [Display(Name = "IATA No")]
        [Range(typeof(decimal), "0", "9999")]
        public Nullable<decimal> IATANo { get; set; }
        [Range(typeof(decimal), "0", "99999999")]
        [Display(Name = "Company Registration Number")]
        public Nullable<decimal> CompanyRegistrationNumber { get; set; }
    }
}
