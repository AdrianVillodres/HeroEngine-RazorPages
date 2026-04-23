using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Core.Models
{
    public class Warrior : AHero
    {
        const int baseArmor = 10;
        public int Armor {  get; set; }
        public string WarCry { get; set; }

        public Warrior(string name, int level, string warCry): base(name, level)
        {
            Armor = (int)(baseArmor + (level - 1)); ;
            WarCry = warCry;
        }

        /// <summary>
        /// An override to the presentation method of the AHero class
        /// </summary>
        /// <returns>The base presentation string with the warrior properties added</returns>
        public override string Presentation() => base.Presentation() + $" | Armor: {Armor} | War Cry: {WarCry}"; //This way I don't reuse code

        public override void TakeDamage(int rawDamageTaken)
        {
            rawDamageTaken -= base.defenseBuffCount * 2;
            int trueDamageTaken = rawDamageTaken - Armor;
            

            if (trueDamageTaken < 0)
            {
                trueDamageTaken = 0;
            }

            CurrentHealth -= trueDamageTaken;

            if (CurrentHealth < 0)
            {
                CurrentHealth = 0;
            }
            //Console.WriteLine($"{Name} recieves {rawDamageTaken} -> absorbed {Armor} by armor -> net damage: {trueDamageTaken} | HP: {CurrentHealth}/{MaxHP}");

            if (!IsAlive)
            {
                Console.WriteLine($"{Name} has been defeated!");
            }


        }
        public override string GetExtraInfo()
        {
            return $" | Absorbed: {Armor}";
        }


    }
}
