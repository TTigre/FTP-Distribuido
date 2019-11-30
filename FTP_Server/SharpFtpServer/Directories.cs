using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace SharpFtpServer
{
    [Serializable]
    public class MyDirectory
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("date")]
        public DateTime Date { get; set; }
        [XmlAttribute("isfile")]
        public bool IsFile { get; set; }

    }
    [Serializable]
    public class MyFileDescriptor
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("date")]
        public DateTime Date { get; set; }

        [XmlAttribute("Size")]
        public int Size { get; set; }
        [XmlAttribute("Parts")]
        public int Parts { get; set; }
    }
   public static class DirectoryMethods
    {
        public static FileStream CreateDirectory(string pathname)
        {
            List<MyDirectory> directories = new List<MyDirectory>();
            XmlSerializer serializer = new XmlSerializer(directories.GetType(), new XmlRootAttribute("MyDirectory"));
            using (StreamWriter w = new StreamWriter(pathname + ".infod")) 
            {
                serializer.Serialize(w, directories);
            }
            return new FileStream(pathname + ".infod", FileMode.Open);
        }
        public static FileStream CreateDescriptor(string pathname, int size)
        {
            List<MyFileDescriptor> files = new List<MyFileDescriptor>();
            XmlSerializer serializer = new XmlSerializer(files.GetType(), new XmlRootAttribute("MyFileDescriptor"));
            using (StreamWriter w = new StreamWriter(pathname + ".info"))
            {
                files.Add(new MyFileDescriptor
                {
                    Name = pathname,
                    Date = System.DateTime.Now,
                    Size = size,
                    Parts = size / (1 << 20)
                });
                serializer.Serialize(w, files);
            }
            return new FileStream(pathname + ".info", FileMode.Open);
        }
        public static FileStream ModifyDirectory(FileStream directory, string name, bool isfile=false)
        {
            List<MyDirectory> directories = new List<MyDirectory>();
            XmlSerializer serializer = new XmlSerializer(directories.GetType(), new XmlRootAttribute("MyDirectory"));
            directories = serializer.Deserialize(new StreamReader(directory)) as List<MyDirectory>;
            directories.Add(new MyDirectory
            {
                Name = name,
                Date = System.DateTime.Now,
                IsFile = isfile
                });
            using (StreamWriter w = new StreamWriter(directory))
            {
                serializer.Serialize(w, directories);
            }
            return directory;
        }
    }
}
