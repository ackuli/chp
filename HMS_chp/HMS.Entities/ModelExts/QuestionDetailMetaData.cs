using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities.Models
{
    public partial class QuestionDetailMetaData
    {
        [Display(Name = "Question Id")]
        public int QuestionId { get; set; }

        [Display(Name = "Question Details Text")]
        [Required(ErrorMessage = "The Question Details Text field is required.")]
        [StringLength(500)]
        public string QuestionDetailsText { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
    }
}
