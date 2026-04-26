using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Core.Core.Models
{
    public class CombatResult //this class is just for centralize the information to make it easier to write in the csv file
    {
        public DateTime Date { get; set; }
        public string Heroes { get; set; }
        public string Enemies { get; set; }
        public string Result { get; set; }
        public int TotalRounds { get; set; }
        public int TotalDamage { get; set; }
        public string BestHero { get; set; }
    }
}
