using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroEngine.Core.Enums;

namespace HeroEngine.Core.Models
{
    public class Ability
    {
        public string Name {  get; }
        public Rarity Rarity { get;}
        public AbilityType Type { get;}

        public int Cost { get;}

        public int Power { get;}

        public Ability(string name, Rarity rarity, AbilityType type)
        {
            Name = name;
            Rarity = rarity;
            Type = type;
            Cost = (int)Rarity;
            Power = (int)Rarity * 2;
        }

        /// <summary>
        /// This is an override of the ToString method to show the ability parameters
        /// </summary>
        /// <returns>the full string of the ability</returns>
        public override string ToString() => $"[{Rarity}]   {Name}  |   Type: {Type}    |   Cost: {Cost} mana";
    }
}
