using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities.Models
{
   public partial class  NewsMetaData
    {

        [Required(ErrorMessage = "The Source Date  Required")]
        [Display(Name = "Source Date")]       
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
       public System.DateTime SourceDate { get; set; }

        [Required(ErrorMessage = "The Publish Date  Required")]
        [Display(Name = "Publish Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public System.DateTime PublishDate { get; set; }
        [Required(ErrorMessage = "The Description   Required")]
        [Display(Name = "Description")]

        public System.DateTime Description { get; set; }


        [Required(ErrorMessage = "The Source  Required")]
        [Display(Name = "Source")]

        public string Source { get; set; }
       
    }
}
