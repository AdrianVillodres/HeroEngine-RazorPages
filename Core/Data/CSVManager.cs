using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace HeroEngine.Core.Core.Data
{
    public static class CsvManager
    {
        public static List<T> Read<T>(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("File not found");
            }

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                PrepareHeaderForMatch = args => args.Header.ToLower()
            };

            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, config);

            return csv.GetRecords<T>().ToList();
        }

        public static void Write<T>(string path, List<T> records)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                HasHeaderRecord = true
            };

            using var writer = new StreamWriter(path);
            using var csv = new CsvWriter(writer, config);

            csv.WriteRecords(records);
        }

        public static void Append<T>(string path, List<T> records)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";"
            };

            bool fileExists = File.Exists(path);
            long fileLength = fileExists ? new FileInfo(path).Length : 0;

            using var stream = File.Open(path, FileMode.Append);
            using var writer = new StreamWriter(stream);
            using var csv = new CsvWriter(writer, config);

            if (!fileExists || fileLength == 0)
            {
                csv.WriteHeader<T>();
                csv.NextRecord();
            }

            csv.WriteRecords(records);
        }

        public static void Append<T>(string path, T record)
        {
            bool fileExists = File.Exists(path);

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                HasHeaderRecord = !fileExists
            };

            using var stream = File.Open(path, FileMode.Append);
            using var writer = new StreamWriter(stream);
            using var csv = new CsvWriter(writer, config);

            csv.WriteRecord(record);
            csv.NextRecord();
        }
    }
}