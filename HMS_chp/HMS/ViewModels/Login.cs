using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HMS.ViewModels
{
    public class Login
    {
        [Required(ErrorMessage = "User Id is required")]
        [Display(Name = "User ID")]
        public string UserID { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public string Message { get; set; }
    }
}