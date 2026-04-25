using HeroEngine.Core.Core.Data;
using HeroEngine.Core.Core.Models;
using HeroEngine.Core.Data;
using HeroEngine.Core.Models;
using System.Security.Cryptography.X509Certificates;

namespace HeroEngine.Core.UI
{
    public class Program
    {
        public static void Main()
        {
            string configPath = "../../../../HeroEngine.Web/Data/game_config.xml";
            string rootName = "game_config";
            var configList = XmlManagerSerialization.Read<GameConfig>(configPath, rootName);
            GameConfig currentConfig = configList.FirstOrDefault();
            //First Chapter
            Console.WriteLine("------------------Heroes---------------------");
            Console.WriteLine();
            Warrior abalon = new Warrior("Abalon", 3, "Who dares challenge me?!", currentConfig.LevelMultiplier);
            Mage dalia = new Mage("Dalia", 3, currentConfig.LevelMultiplier);
            Rogue mercer = new Rogue("Mercer Frey", 2, 2, 10, currentConfig.LevelMultiplier);

            Console.WriteLine(abalon.Presentation());
            Console.WriteLine("------------");
            Console.WriteLine(dalia.Presentation());
            Console.WriteLine("------------");
            Console.WriteLine(mercer.Presentation());
            abalon.TakeDamage(dalia.Attack(13));
            Console.WriteLine(abalon.Presentation());
            Console.WriteLine();

            //Second Chapter
            Console.WriteLine("------------------Armoury---------------------");
            Console.WriteLine();
            Ability swartz = new Ability("Swartz of the Ice Queen", Rarity.Legendary, AbilityType.Attack);
            Ability hellfire = new Ability("Hellfire of demise", Rarity.Epic, AbilityType.Attack);
            Ability airCutter = new Ability("Air cutter", Rarity.Common, AbilityType.Attack);
            Ability corrupt = new Ability("Corrupt memory", Rarity.Rare, AbilityType.Attack);
            Ability heal = new Ability("Healing hands", Rarity.Rare, AbilityType.Healing);
            Ability defense = new Ability("defense", Rarity.Rare, AbilityType.Defense);
            Ability buff = new Ability("buff", Rarity.Rare, AbilityType.Support);
            Console.WriteLine(swartz);

            //I make this many add to the abilities to be able to test all the posibilities
            dalia.AddAbility(swartz);
            dalia.AddAbility(heal);
            abalon.AddAbility(hellfire);
            mercer.AddAbility(airCutter);
            dalia.AddAbility(defense);
            dalia.AddAbility(buff);
            Console.WriteLine("----------------------------------------------------------------------");
            dalia.ListAllAbilities();
            Console.WriteLine("----------------------------------------------------------------------");
            dalia.CastAbility(swartz, abalon);
            Console.WriteLine(abalon.Presentation());
            Console.WriteLine("----------------------------------------------------------------------");
            dalia.CastAbility(heal, abalon);
            Console.WriteLine(abalon.Presentation());
            Console.WriteLine("----------------------------------------------------------------------");
            dalia.CastAbility(defense, abalon);
            dalia.CastAbility(defense, abalon);
            dalia.CastAbility(defense, abalon);
            dalia.CastAbility(swartz, abalon);
            Console.WriteLine(abalon.Presentation());
            Console.WriteLine("----------------------------------------------------------------------");
            dalia.CastAbility(buff, abalon);
            dalia.CastAbility(buff, abalon);
            dalia.CastAbility(buff, abalon);
            dalia.TakeDamage(abalon.Attack(13));
            Console.WriteLine(dalia.Presentation());
            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine();

            //Third Chapter
            Console.WriteLine("------------------Combat System---------------------");
            Console.WriteLine();
            dalia.CurrentHealth = dalia.MaxHP;
            abalon.CurrentHealth = abalon.MaxHP;
            Minion loki = new Minion("Loki");
            Elite shadow = new Elite("Shadow");
            Boss altair = new Boss("Altair");
            Console.WriteLine(loki);
            Console.WriteLine(shadow);
            Console.WriteLine(altair);
            loki.AddAbility(corrupt);
            shadow.AddAbility(corrupt);
            altair.AddAbility(corrupt);
            List<ACharacter> fighters = new List<ACharacter>();
            List<AHero> heroes = new List<AHero>();
            fighters.Add(abalon);
            fighters.Add(dalia);
            fighters.Add(mercer);
            fighters.Add(loki);
            fighters.Add(shadow);
            fighters.Add(altair);
            heroes.Add(abalon);
            heroes.Add(dalia);
            heroes.Add(mercer);         
            int heroCount = fighters.Count(f => f.CharType == CharType.HERO);
            HeroRepository repo = new HeroRepository();
            repo.SaveAll(heroes);
            //Validate Heroes quantity
            currentConfig.ValidateParty(fighters);  
            CombatSystem ui = new CombatSystem(currentConfig);
            ui.Combat(fighters);

            var analytics = new HeroAnalytics(heroes);
            
            List<AHero> topHeroes = analytics.GetTopHeroesByLevel(3);
            List<Ability> abilitiesByRarity = analytics.GetAbilitiesByRarity(Rarity.Legendary);
            List<AHero> heroesByAbilityCount = analytics.GetHeroesWithAbilityCount(1);
            var damagePerClass = analytics.GetAverageDamagePerClass();
            List<AHero> searchResults = analytics.SearchHeroesByName("Dalia");

            topHeroes.ForEach(h => Console.WriteLine(h.Name));
            abilitiesByRarity.ForEach(a => Console.WriteLine(a.Name));
            heroesByAbilityCount.ForEach(h => Console.WriteLine(h.Name));
            damagePerClass.ToList().ForEach(d => Console.WriteLine($"{d.Key}: {d.Value}"));
            searchResults.ForEach(h => Console.WriteLine(h.Name));

        }
    }
}
