using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QuickImageCompare
{
    [DataContract]
    public class FolderMetadata
    {
        [DataMember]
        public List<FolderMetadataItem> Items;
         
        public string FolderName;

        public static FolderMetadata GetFromFolder(string folderName)
        {
            var metaDataFile = folderName + @"\metadata.xml";
            FolderMetadata result = null;

            try
            {
                if (File.Exists(metaDataFile))
                {
                    using (var fs = File.OpenRead(metaDataFile))
                    {
                        var dcs = new DataContractSerializer(typeof (FolderMetadata));
                        result = dcs.ReadObject(fs) as FolderMetadata;

                    }
                }
            }
            catch (Exception ex) { }

            if(result == null)
            {
                result = new FolderMetadata();
                result.Items = new List<FolderMetadataItem>();
            }

            result.FolderName = folderName + @"\";
            if (result.Items == null) result.Items = new List<FolderMetadataItem>();

            var files = Directory.GetFiles(folderName);
            foreach (var file in files)
            {
                var lcase = file.ToLower();
                if (lcase.EndsWith(".jpg")
                    || lcase.EndsWith(".gif")
                    || lcase.EndsWith(".png")
                    || lcase.EndsWith(".bmp")
                    || lcase.EndsWith(".tif"))
                {
                    var exists = result.Items.FindIndex(0, x => x.FileName.Equals(lcase)) >= 0;
                    if (!exists)
                    {
                        result.Items.Add(
                            new FolderMetadataItem
                                {
                                    FileName = lcase
                                }
                            );
                    }
                }
            }

            var ix = 0;
            while (ix < result.Items.Count)
            {
                var item = result.Items[ix];
                if (!File.Exists(item.FileName))
                {
                    result.Items.RemoveAt(ix);
                }
                else
                {
                    ix++;
                }
            }


            return result;

        }

        public void Save()
        {
            var metaDataFile = FolderName + "metadata.xml";
            using (var fs = File.OpenWrite(metaDataFile))
            {
                var dcs = new DataContractSerializer(typeof(FolderMetadata));
                dcs.WriteObject(fs,this);

            }
        }

        public void Process()
        {
            if (!Directory.Exists(FolderName + "Retouch")) Directory.CreateDirectory(FolderName + "Retouch");
            if (!Directory.Exists(FolderName + "Delete")) Directory.CreateDirectory(FolderName + "Delete");
            if (!Directory.Exists(FolderName + "Keep")) Directory.CreateDirectory(FolderName + "Keep");

            foreach (var item in Items)
            {
                var destination = FolderName + item.Action.ToString() + @"\" + item.FileName.Substring(FolderName.Length);
                File.Move(item.FileName,destination);
            }
        }
    }
}
