using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HMS.Entities.Models
{
    [MetadataType(typeof(NewsMetaData))]
    public partial class News : Entity
    {
       
    }
}
