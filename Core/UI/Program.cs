using System.Security.Cryptography.X509Certificates;
using HeroEngine.Core.Models;

namespace HeroEngine.Core.UI
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("------------------Heroes---------------------");
            Console.WriteLine();
            Warrior abalon = new Warrior("Abalon", 3, "Who dares challenge me?!");
            Mage dalia = new Mage("Dalia", 3);
            Rogue mercer = new Rogue("Mercer Frey", 2, 2, 10);

            Console.WriteLine(abalon.Presentation());
            Console.WriteLine("------------");
            Console.WriteLine(dalia.Presentation());
            Console.WriteLine("------------");
            Console.WriteLine(mercer.Presentation());
            abalon.TakeDamage(dalia.Attack(13));
            Console.WriteLine(abalon.Presentation());
            Console.WriteLine();
            Console.WriteLine("------------------Armoury---------------------");
            Console.WriteLine();
            Ability swartz = new Ability("Swartz of the Ice Queen", Enums.Rarity.Legendary, Enums.AbilityType.Attack);
            Ability hellfire = new Ability("Hellfire of demise", Enums.Rarity.Legendary, Enums.AbilityType.Attack);
            Ability heal = new Ability("Healing hands", Enums.Rarity.Rare, Enums.AbilityType.Healing);
            Ability defense = new Ability("defense", Enums.Rarity.Rare, Enums.AbilityType.Defense);
            Ability buff = new Ability("buff", Enums.Rarity.Rare, Enums.AbilityType.Support);
            Console.WriteLine(swartz);

            dalia.AddAbility(swartz);
            dalia.AddAbility(heal);
            dalia.AddAbility(hellfire);
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
            Console.WriteLine("------------------Combat System---------------------");
            Console.WriteLine();
            Minion loki = new Minion("Loki");
            Elite shadow = new Elite("Shadow");
            Boss altair = new Boss("Altair");
            Console.WriteLine(loki);
            Console.WriteLine(shadow);
            Console.WriteLine(altair);
            List<ACharacter> combatants = new List<ACharacter>();
            combatants.Add(abalon);
            combatants.Add(dalia);
            combatants.Add(mercer);
            combatants.Add(loki);
            combatants.Add(shadow);
            combatants.Add(altair);
        }
    }
}
