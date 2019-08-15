using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entities.Models
{
    [MetadataType(typeof(ClientMetaData))]
    public partial class Client: Entity
    {
         public BinaryObject binaryObject;
         public List<KeyValuePair<int, string>> clientList { get; set; }
         public List<KeyValuePair<int, string>> roleList { get; set; }
         public List<KeyValuePair<int, string>> ministryApprovalList { get; set; }

    }
}
