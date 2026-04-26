using HeroEngine.Core.Models;
using System.Xml.Serialization;

namespace HeroEngine.Core.Core.Models
{
    [XmlType("game_config")]
    public class GameConfig
    {
        public double LevelMultiplier { get; set; }
        public double CriticalHitChance { get; set; }
        public int MaxCombatRounds { get; set; }
        public int MaxHeroesPerBattle { get; set; }

        public override string ToString() => $"Rounds: {MaxCombatRounds}, Multiplier: {LevelMultiplier}, Crit Rate: {CriticalHitChance}";

        public void ValidateParty(List<ACharacter> fighters)
        {
            const string Warning_MSG = "Battle party exceeds the limit of {0} heroes.";
            const string Remove_MSG = " {0} has been removed from the battle party.";

            int heroCount = fighters.Count(f => f.CharType == CharType.HERO);

            if (heroCount > MaxHeroesPerBattle)
            {
                Console.WriteLine(Warning_MSG, MaxHeroesPerBattle);

                for (int i = fighters.Count - 1; i >= 0; i--)
                {
                    if (fighters[i].CharType == CharType.HERO && heroCount > MaxHeroesPerBattle)
                    {
                        Console.WriteLine(Remove_MSG, fighters[i].Name);
                        fighters.RemoveAt(i);
                        heroCount--;
                    }
                }
            }
        }
    }
}
    
