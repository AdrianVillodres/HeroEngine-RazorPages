using System;
using System.Collections.Generic;
using System.Linq;
using HeroEngine.Core.Enums;

namespace HeroEngine.Core.Models
{
    public class CombatHelper
    {
        public int Damage { get; set; } = 0;

        /// <summary>
        /// This method is used to calculate de total damage in the combat engine
        /// </summary>
        /// <param name="dmg">Damage of the hero</param>
        public void TotalDamage(int dmg)
        {
            Func <int, int, int> sum = (a, b) => a + b;
            Damage = sum(Damage, dmg);
        }

        /// <summary>
        /// This method is used to know the hero with the hero that performed better in combat
        /// </summary>
        /// <param name="fighters">the list of fighters in the combat</param>
        /// <returns>the name of the hero with most damage dealed</returns>
        public string MostProfitableHero(List<ACharacter> fighters)
        {
            string name = "";
            int index = 0;
            fighters.GroupBy(f => f.TotalDamage);
            while(name == "")
            {
                if (fighters[index].CharType.Equals(CharType.ENEMY))
                    index++;
                else
                    name = fighters[index].Name;
            }
            return name;
        }

        /// <summary>
        /// This method shows the enemy that was defeated in less rounds
        /// </summary>
        /// <param name="defeatedCharacters">the list of the characters that are dead</param>
        /// <returns>the name of the enemy that was killed in less rounds</returns>
        public string EnemyDefeatedFirst(List<ACharacter> defeatedCharacters)
        {
            ACharacter enemy = defeatedCharacters.FirstOrDefault(f => f.CharType == CharType.ENEMY);

            if (enemy == null)
                return "No enemies defeated";

            return enemy.Name;
        }
    }
}