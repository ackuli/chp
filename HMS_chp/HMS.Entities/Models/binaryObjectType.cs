using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class BinaryObjectType
    {
        public BinaryObjectType()
        {
            this.BinaryObjects = new List<BinaryObject>();
        }

        public int BinaryObjectsTypeId { get; set; }
        public string ObjectTypeSource { get; set; }
        public string Name { get; set; }
        public virtual ICollection<BinaryObject> BinaryObjects { get; set; }
    }
}
