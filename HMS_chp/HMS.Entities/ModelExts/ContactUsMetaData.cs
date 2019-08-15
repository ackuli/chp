using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities.Models
{
  public partial  class ContactUsMetaData
    {

        [Required(ErrorMessage = "The Name Required")]
        public string Name { get; set; }
              
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
        
        public string Address { get; set; }
       
        public string Country { get; set; }
        
        public string ContactNumber { get; set; }
        [Required(ErrorMessage = "The Email Required")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }


       
        public string Subject { get; set; }

        [Required(ErrorMessage = "The Message Required")]       
        public string Message { get; set; }
        public bool IsActive { get; set; }
        public Nullable<System.DateTime> LastUpdateTime { get; set; }
        public string Captcha { get; set; }
    }
}
