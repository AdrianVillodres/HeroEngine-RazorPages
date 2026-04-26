using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HeroEngine.Core.Core.Data
{
    public static class XmlManagerSerialization
    {

        public static void CreateFile<T>(string path, string rootName)
        {
            if (File.Exists(path))
            {
                return;
            }
            var serializer = new XmlSerializer(typeof(List<T>), new XmlRootAttribute(rootName));
            using var stream = new FileStream(path, FileMode.Create);
            serializer.Serialize(stream, new List<T>());
        }

        public static List<T> Read<T>(string path, string rootName)
        {
            if (!File.Exists(path))
            {
                CreateFile<T>(path, rootName);
            }


            var serializer = new XmlSerializer(typeof(List<T>), new XmlRootAttribute(rootName));

            using var stream = new FileStream(path, FileMode.Open);

            return serializer.Deserialize(stream) as List<T> ?? new List<T>();
        }

        public static void Write<T>(string path, List<T> records, string rootName)
        {
            var serializer = new XmlSerializer(typeof(List<T>), new XmlRootAttribute(rootName));

            using var stream = new FileStream(path, FileMode.Create);

            serializer.Serialize(stream, records);
        }

        public static void Append<T>(string path, T obj, string rootName)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            var records = Read<T>(path, rootName);

            records.Add(obj);

            Write(path, records, rootName);
        }

        public static void Append<T>(string path, List<T> objs, string rootName)
        {
            if (objs == null || objs.Count == 0)
            {
                throw new ArgumentException("The list can't be empty", nameof(objs));
            }
            var records = Read<T>(path, rootName);

            records.AddRange(objs);

            Write(path, records, rootName);

        }



    }
}

