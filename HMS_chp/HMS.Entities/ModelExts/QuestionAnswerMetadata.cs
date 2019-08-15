using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
namespace HMS.Entities.Models
{
    public partial class QuestionAnswerMetadata
    {
        [Required(ErrorMessage = "The Question field is required.")]
        [AllowHtml]
        public string Question { get; set; }
        [AllowHtml]
        public string KeyWords { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }

        [Display(Name = "Question Category")]
        [Required(ErrorMessage = "The Question Category is required.")]
        public int TypeId { get; set; }

         [Display(Name = "Email Address")]
         [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
         [Required(ErrorMessage = "The Email Address is required.")]
        public string EmailId { get; set; }

    }
}
