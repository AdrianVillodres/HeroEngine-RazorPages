using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Core.Models
{
    public abstract class ACharacter
    {
        public string Name { get; set; }
        public int MaxHP { get; set; }

        public const int baseHealth = 100;
        public int CurrentHealth { get; set; }
        public int defenseBuffCount { get; set; }

        public int attackBuffCount { get; set; }

        public int Speed { get; protected set; }
        public ACharacter(string name)
        {
            Name = name;
            MaxHP = 100;
            defenseBuffCount = 0;
            attackBuffCount = 0;
        }

        /// <summary>
        /// This method is used to attack another hero
        /// </summary>
        /// <param name="damage">The raw damage points of the attack</param>
        /// <returns>The real damage of the attack</returns>
        public virtual int Attack(int damage)
        {
            if (!IsAlive)
            {
                Console.WriteLine($"{Name} is defeated and cannot attack.");
                return 0;
            }

            Console.WriteLine($"{Name} attacks! Deals {damage} damage");
            return damage + (attackBuffCount * 2);
        }

        /// <summary>
        /// This method is used to make the hero take the damage from another hero's attacks
        /// </summary>
        /// <param name="rawDamageTaken">The raw damage of the attack</param>
        public virtual void TakeDamage(int rawDamageTaken)
        {
            rawDamageTaken -= attackBuffCount * 2;
            CurrentHealth -= rawDamageTaken;
            if (CurrentHealth < 0)
            {
                CurrentHealth = 0;
            }
            Console.WriteLine($"{Name} recieves {rawDamageTaken} | HP: {CurrentHealth}/{MaxHP}");

            if (!IsAlive)
            {
                Console.WriteLine($"{Name} has been defeated!");
            }
        }

        public bool IsAlive => CurrentHealth > 0;
    }

}
