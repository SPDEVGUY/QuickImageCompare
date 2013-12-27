using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace QuickImageCompare
{
    [DataContract]
    public class FolderMetadataItem
    {
        [DataMember]
        public string FileName;
        [DataMember]
        public ItemAction Action;
    }

    public enum ItemAction
    {
        Keep,
        Delete,
        Retouch
    }
}
