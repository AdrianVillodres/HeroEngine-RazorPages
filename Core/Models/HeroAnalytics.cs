using HeroEngine.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HeroEngine.Core.Core.Models
{
    public class HeroAnalytics
    {
        private readonly List<AHero> _heroes;
        public HeroAnalytics(List<AHero> heroes)
        {
            _heroes = heroes;
        }

        public List<AHero> GetTopHeroesByLevel(int n)
        {
            return _heroes
                .OrderByDescending(h => h.Level)
                .Take(n)
                .ToList();
        }

        public List<Ability> GetAbilitiesByRarity(Rarity rarity)
        {
            return _heroes
                .SelectMany(h => h.abilities)
                .Where(a => a.Rarity == rarity)
                .ToList();
        }

        public List<AHero> GetHeroesWithAbilityCount(int min)
        {
            return _heroes
                .Where(h => h.abilities.Count >= min)
                .ToList();
        }

        public Dictionary<string, double> GetAverageDamagePerClass()
        {
            return _heroes
                .GroupBy(h => h.GetType().Name)
                .ToDictionary(
                    group => group.Key,
                    Group => Group.Average(h => (double)h.TotalDamage)
                );
        }

        public List<AHero> SearchHeroesByName(string pattern)
        {
            return _heroes
                .Where(h => Regex.IsMatch(h.Name, pattern, RegexOptions.IgnoreCase))
                .ToList();
        }
    }
}
