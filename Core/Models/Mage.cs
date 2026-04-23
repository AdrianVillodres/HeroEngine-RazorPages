using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Core.Models
{
    public class Mage : AHero
    {
        const int baseMana = 100;
        const int baseArcane = 20;
        public int Mana {  get; set; }
        public int Arcane { get; set; }
        public Mage(string name, int level) : base(name, level)
        {
            Mana = (int)(baseMana * (1 + 0.50 * (level - 1)));
            Arcane = (int)(baseArcane + (level - 1));
        }

        public override string Presentation() => base.Presentation() + $" | Mana: {Mana} | Arcane: {Arcane}"; //This way I don't reuse code

        public override int Attack(int damage)
        {
            Mana -= 20;
            return base.Attack(damage);
        }
    }
}
