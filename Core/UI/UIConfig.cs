using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroEngine.Core.Models;

namespace HeroEngine.Core.UI
{
    public class UIConfig
    {
        const string BattleLogMSG = "  BATTLE LOG - Round {0}";
        int round = 1;
        public void Combat(List<ACharacter> fighters)
        {
            while (fighters.Any(c => c is AHero && c.IsAlive) &&
                   fighters.Any(c => c is AEnemy && c.IsAlive))
            {
                Console.WriteLine("==================================================");
                Console.WriteLine(BattleLogMSG, round);
                Console.WriteLine("==================================================");

                fighters.Sort((a, b) => b.Speed.CompareTo(a.Speed));
                var alivefighters = fighters.FindAll(c => c.IsAlive);

                foreach (var fighter in fighters)
                {
                    var target = fighters.Find(t => t.IsAlive && t.GetType() != fighter.GetType());

                }
            }
        }
    }
}
