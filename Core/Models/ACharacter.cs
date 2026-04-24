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

        public int TotalDamage { get; set; }

        public int Speed { get; protected set; }

        public CharType CharType { get; set; }

        public List<Ability> abilities { get; set; } = new List<Ability>();

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
        /// This method is used to attack another hero, used for the combat engine
        /// </summary>
        /// <param name="damage">The raw damage points of the attack</param>
        /// <returns>The real damage of the attack</returns>
        public virtual int AttackEngine(int damage)
        {
            if (!IsAlive)
            {
                Console.WriteLine($"{Name} is defeated and cannot attack.");
                return 0;
            }

            return damage + (attackBuffCount * 2);
        }

        /// <summary>
        /// This method is used to make the hero take the damage from another hero's attacks
        /// </summary>
        /// <param name="rawDamageTaken">The raw damage of the attack</param>
        public virtual void TakeDamage(int rawDamageTaken)
        {
            rawDamageTaken -= defenseBuffCount * 2;

            if (rawDamageTaken < 0)
            {
                rawDamageTaken = 0;
            }

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

        /// <summary>
        /// This method is used to make the hero take the damage from another hero's attacks, used excusively for the combat engine
        /// </summary>
        /// <param name="rawDamageTaken">The raw damage of the attack</param>
        public virtual void TakeDamageEngine(int rawDamageTaken)
        {
            rawDamageTaken -= defenseBuffCount * 2;

            if (rawDamageTaken < 0)
            {
                rawDamageTaken = 0;
            }

            CurrentHealth -= rawDamageTaken;

            if (CurrentHealth < 0)
            {
                CurrentHealth = 0;
            }

            if (!IsAlive)
            {

            }
        }

        public bool IsAlive => CurrentHealth > 0;

        /// <summary>
        /// This method will be used to get extra information in case the hero or enemy has armor or something like that
        /// </summary>
        /// <returns>an empty string</returns>
        public virtual string GetExtraInfo()
        {
            return "";
        }

        /// <summary>
        /// This method casts the ability of the hero in case the hero has it and makes different effects depending on the ability type
        /// </summary>
        /// <param name="ability">the ability full object</param>
        /// <param name="hero">the hero full object</param>
        public void CastAbility(Ability ability, ACharacter target)
        {
            if (abilities.Contains(ability))
            {
                switch (ability.Type)
                {
                    case AbilityType.Attack:
                        Console.WriteLine($"Casting '{ability.Name}' [{ability.Rarity}]...");
                        Console.WriteLine($"{Name} inficts {ability.Power} of damage to {target.Name}");
                        target.TakeDamage(ability.Power);
                        break;
                    case AbilityType.Healing:
                        Console.WriteLine($"Casting '{ability.Name}' [{ability.Rarity}]...");
                        Console.WriteLine($"{Name} heals {ability.Power} of HP to {target.Name}");
                        target.CurrentHealth += ability.Power;
                        break;
                    case AbilityType.Defense:
                        Console.WriteLine($"Casting '{ability.Name}' [{ability.Rarity}]...");
                        Console.WriteLine($"{Name} upgrade defense of {target.Name}");
                        target.defenseBuffCount++;
                        break;
                    case AbilityType.Support:
                        Console.WriteLine($"Casting '{ability.Name}' [{ability.Rarity}]...");
                        Console.WriteLine($"{Name} upgrade attack of {target.Name}");
                        target.attackBuffCount++;
                        break;
                }
            }
            else
            {
                Console.WriteLine($"{Name} does not have this ability");
            }
        }

        /// <summary>
        /// This method casts the ability of the hero in case the hero has it and makes different effects depending on the ability type, used in the combat engine
        /// </summary>
        /// <param name="ability">the ability full object</param>
        /// <param name="hero">the hero full object</param>
        public void CastAbilityEngine(Ability ability, ACharacter target)
        {
            if (abilities.Contains(ability))
            {
                switch (ability.Type)
                {
                    case AbilityType.Attack:
                        target.TakeDamageEngine(ability.Power);
                        break;
                    case AbilityType.Healing:
                        target.CurrentHealth += ability.Power;
                        break;
                    case AbilityType.Defense:
                        target.defenseBuffCount++;
                        break;
                    case AbilityType.Support:
                        target.attackBuffCount++;
                        break;
                }
            }
            else
            {
                Console.WriteLine($"{Name} does not have this ability");
            }
        }

        /// <summary>
        /// This method adds an ability to the hero in case the ability is not already added and sorts the abilities ordering them for the rarity
        /// </summary>
        /// <param name="ability">The ability full object</param>
        public void AddAbility(Ability ability)
        {
            Predicate<Ability> same = a => a.Name == ability.Name;
            if (abilities.Exists(same))
            {
                Console.WriteLine($"The ability {ability.Name} already exists");
            }
            else
            {
                abilities.Add(ability);
                abilities.Sort((a, b) => a.Rarity.CompareTo(b.Rarity));
                Console.WriteLine($"The ability {ability.Name} has benn added succesfully");
            }
        }

        /// <summary>
        /// This method lists all the abilities that the hero has
        /// </summary>
        public void ListAllAbilities()
        {
            Console.WriteLine("=============================================================================");
            Console.WriteLine($"{Name} ABILITY LOADOUT");
            foreach (Ability ability in abilities)
            {
                Console.WriteLine($"[{ability.Rarity}]   {ability.Name}  |   Type: {ability.Type}    |   Cost: {ability.Cost} mana");
            }
            Console.WriteLine("=============================================================================");
        }


    }

}
