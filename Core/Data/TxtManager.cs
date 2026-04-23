using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Core.TXTParsing
{
    public static class TxtManager
    {
        public static void Write<T>(string path, T obj)
        {
            File.WriteAllText(path, obj?.ToString() ?? string.Empty);
        }

        
        public static void Append<T>(string path, T obj)
        {

            string content = obj?.ToString() ?? string.Empty;


            if (File.Exists(path) && new FileInfo(path).Length > 0)
            {

                File.AppendAllText(path, Environment.NewLine + content);
            }
            else
            {
                File.AppendAllText(path, content);
            }
        }
    }
}
