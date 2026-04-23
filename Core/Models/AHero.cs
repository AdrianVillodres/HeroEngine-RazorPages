using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace HeroEngine.Core.Models
{
    public abstract class AHero : ACharacter
    {
        public int Level { get; }
        
        public AHero(string name, int level) : base(name)
        {
            Name = name;
            Level = level;
            MaxHP = (int)(baseHealth * (1 + 0.25 * (level - 1)));
            CurrentHealth = MaxHP;
            Speed = 100 * Level;
            CharType = CharType.HERO;
        }

        /// <summary>
        /// This method is used to see the stats of the hero
        /// </summary>
        /// <returns>The full string of the stats of the hero</returns>
        public virtual string Presentation() => $"[Hero] {Name} | Level: {Level} | HP: {CurrentHealth}/{MaxHP}";

        /// <summary>
        /// override of the attack method, used to attack a character
        /// </summary>
        /// <param name="damage">The raw damage points of the attack</param>
        /// <returns>The real damage of the attack</returns>
        public override int Attack(int damage)
        {
            if (!IsAlive)
                return 0;

            if (abilities.Count > 0)
            {
                Ability ability = abilities[0];
                Console.WriteLine($"{Name} uses {ability.Name}");
                return ability.Power + (attackBuffCount * 2);
            }

            return base.Attack(damage);
        }

        /// <summary>
        /// override of the AttackEngine method, used to attack a character, used in the combat engine
        /// </summary>
        /// <param name="damage">The raw damage points of the attack</param>
        /// <returns>The real damage of the attack</returns>
        public override int AttackEngine(int damage)
        {
            if (!IsAlive)
                return 0;

            if (abilities.Count > 0)
            {
                Ability ability = abilities[0];
                return ability.Power + (attackBuffCount * 2);
            }

            return base.Attack(damage);
        }

    }
}
