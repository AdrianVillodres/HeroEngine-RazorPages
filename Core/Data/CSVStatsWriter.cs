using HeroEngine.Core.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Core.Core.Data
{
    public class CSVStatsWriter
    {
        public class CsvStatsWriter
        {
            private readonly string _path;

            public CsvStatsWriter(string path = "../../../../HeroEngine.Web/Data/combat_stats.csv")
            {
                string webPath = "Data/combat_stats.csv";
                string corePath = "../../../../HeroEngine.Web/Data/combat_stats.csv";

                if (!File.Exists(path))
                {
                    _path = "../../../../HeroEngine.Web/Data/combat_stats.csv";
                }
                else
                {
                    _path = path;
                }
            }

            public void AppendCombatStats(CombatResult result)
            {
                CsvManager.Append(_path, result);
            }
        }
    }
}
