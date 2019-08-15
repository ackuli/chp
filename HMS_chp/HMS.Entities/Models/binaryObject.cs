using System;
using System.Collections.Generic;

namespace HMS.Entities.Models
{
    public partial class BinaryObject
    {
        public BinaryObject()
        {
            this.PackageSources = new List<PackageSource>();
        }

        public int BinaryObjectsId { get; set; }
        public string Name { get; set; }
        public int RefObjectTypeId { get; set; }
        public int RefObjectKey { get; set; }
        public string BinaryObjectTypeName { get; set; }
        public string ObjectCaption { get; set; }
        public byte[] Object { get; set; }
        public string ScriptContent { get; set; }
        public string ObjectPath { get; set; }
        public string Extension { get; set; }
        public bool IsActive { get; set; }
        public Nullable<System.DateTime> LastUpdatedTime { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string ObjectDescription { get; set; }
        public virtual BinaryObjectType BinaryObjectType { get; set; }
        public virtual ICollection<PackageSource> PackageSources { get; set; }
    }
}
