using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Core.Models
{
    public class Rogue : AHero
    {
        public int FurtiveDamageMultiplier { get; set; }
        public int HiddenDaggers { get; set; }
        public Rogue(string name, int level, int furtiveDamageMultiplier, int hiddenDaggers) : base(name, level)
        {
            FurtiveDamageMultiplier = furtiveDamageMultiplier;
            HiddenDaggers = hiddenDaggers;
        }

        public override string Presentation() => base.Presentation() + $" | Furtive Damage Multiplier: {FurtiveDamageMultiplier} | Hidden Daggers: {HiddenDaggers}";

        public override int Attack(int damage)
        {
            damage *= FurtiveDamageMultiplier;
            return base.Attack(damage);
        }
    }
}
