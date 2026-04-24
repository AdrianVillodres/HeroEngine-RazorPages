using System.Text.Json;

namespace HeroEngine.Core.Data
{
    public class JsonManager
    {
        public static List<T> Read<T>(string path)
        {
            if (!File.Exists(path)) return new List<T>();

            string jsonFromFile = File.ReadAllText(path);
            if (string.IsNullOrWhiteSpace(jsonFromFile)) return new List<T>();

            return JsonSerializer.Deserialize<List<T>>(jsonFromFile) ?? new List<T>();
        }

        public static void Write<T>(string path, T records)
        {
            var directory = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(directory)) Directory.CreateDirectory(directory);

            string jsonString = JsonSerializer.Serialize(records, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, jsonString);
        }

        public static void Write<T>(string path, List<T> records)
        {
            var directory = Path.GetDirectoryName(path);
            if (!string.IsNullOrEmpty(directory)) Directory.CreateDirectory(directory);

            string jsonString = JsonSerializer.Serialize(records, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, jsonString);
        }

        public static void Append<T>(string path, T obj)
        {
            List<T> records = Read<T>(path);

            records.Add(obj);

            Write(path, records);
        }
    }
}