using HeroEngine.Core.Core.Models;
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
        public Rogue(string name, int level, int furtiveDamageMultiplier, int hiddenDaggers, double multiplier) : base(name, level, multiplier)
        {
            FurtiveDamageMultiplier = furtiveDamageMultiplier;
            HiddenDaggers = hiddenDaggers;
        }

        /// <summary>
        /// An override to the presentation method of the AHero class
        /// </summary>
        /// <returns>The base presentation string with the rogue properties added</returns>
        public override string Presentation() => base.Presentation() + $" | Furtive Damage Multiplier: {FurtiveDamageMultiplier} | Hidden Daggers: {HiddenDaggers}";

        /// <summary>
        /// An override of the attack method for the mage, who has a damage multiplier
        /// </summary>
        /// <param name="damage">The raw damage points of the attack</param>
        /// <returns>The real damage of the attack</returns>
        public override int Attack(int damage)
        {
            damage *= FurtiveDamageMultiplier;
            return base.Attack(damage);
        }
    }
}
