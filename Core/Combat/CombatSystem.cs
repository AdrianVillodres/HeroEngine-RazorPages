using HeroEngine.Core.Core.Models;
using HeroEngine.Core.Models;
using HeroEngine.Core.TXTParsing;
using System;
using System.Collections.Generic;
using System.Linq;
using static HeroEngine.Core.Core.Data.CSVStatsWriter;

namespace HeroEngine.Core.UI
{
    public class CombatSystem
    {
        const string BattleLogMSG = "  BATTLE LOG - Round ";
        const string NoFightersMSG = "There are no fighters";
        const string TotalDamageMSG = "The total damage that was dealed in all the combat is: ";
        const string MostProfitableHeroMSG = "The most profitable hero is: ";
        const string EnemyDefeatedFirstMSG = "The enemy that survived least rounds is: ";
        const int baseDamage = 10;

        private readonly GameConfig _config;
        int round = 1;
        Random rand = new Random();

        string path;

        public CombatSystem(GameConfig config, string customPath = "../../../../HeroEngine.Web/Data/combat_log.txt")
        {
            _config = config;
            path = customPath;
        }

        CombatHelper combatHelper = new CombatHelper();
        List<ACharacter> defeatedCharacters = new List<ACharacter>();

        public void Combat(List<ACharacter> fighters)
        {
            TxtManager.Append(path, $"Combat started at {DateTime.Now}");
            if (fighters.Count > 0)
            {


                Directory.CreateDirectory("Files");

                while (fighters.Any(f => f.IsAlive && f.CharType == CharType.HERO) && fighters.Any(f => f.IsAlive && f.CharType == CharType.ENEMY) && round <= _config.MaxCombatRounds)
                {
                    Console.WriteLine("==================================================");
                    Console.WriteLine($"{BattleLogMSG} {round}");
                    Console.WriteLine("==================================================");

                    TxtManager.Append(path, "==================================================");
                    TxtManager.Append(path, $"  BATTLE LOG - Round {round}");
                    TxtManager.Append(path, "==================================================");

                    fighters.Sort((a, b) => b.Speed.CompareTo(a.Speed));

                    foreach (var fighter in fighters)
                    {
                        if (!fighter.IsAlive)
                            continue;

                        ACharacter target = null;
                        string action = "Attack";
                        int hpBefore = 0;

                        if (fighter.abilities.Count > 0)
                        {
                            Ability ability = fighter.abilities[rand.Next(fighter.abilities.Count)];
                            action = ability.Name;

                            if (ability.Type == AbilityType.Attack)
                                target = EnemyTarget(fighters, fighter);
                            else
                                target = AllyTarget(fighters, fighter);

                            if (target != null)
                            {
                                hpBefore = target.CurrentHealth;

                                fighter.CastAbilityEngine(ability, target);

                                if (ability.Type == AbilityType.Attack)
                                {
                                    int dmg = ability.Power + (fighter.attackBuffCount * 2);

                                    fighter.TotalDamage += dmg;
                                    combatHelper.TotalDamage(dmg);

                                    if (!target.IsAlive)
                                        defeatedCharacters.Add(target);
                                }
                            }
                        }
                        else
                        {
                            target = EnemyTarget(fighters, fighter);

                            if (target != null)
                            {
                                hpBefore = target.CurrentHealth;

                                int dmg = fighter.AttackEngine(baseDamage);

                                fighter.TotalDamage += dmg;
                                combatHelper.TotalDamage(dmg);

                                target.TakeDamageEngine(dmg);

                                if (!target.IsAlive)
                                    defeatedCharacters.Add(target);
                            }
                        }

                        if (target != null)
                        {
                            int damageDone = hpBefore - target.CurrentHealth;
                            string defeated = target.IsAlive ? "" : " | DEFEATED!";

                            string log = $"  {fighter.CharType} {fighter.Name} > {action} > {target.Name} -> {damageDone} dmg{defeated}";

                            Console.WriteLine(log);
                            TxtManager.Append(path, log);
                        }
                    }

                    int heroesAlive = fighters.Count(f => f.CharType == CharType.HERO && f.IsAlive);
                    int enemiesAlive = fighters.Count(f => f.CharType == CharType.ENEMY && f.IsAlive);

                    Console.WriteLine("--------------------------------------------------");
                    Console.WriteLine($"  Remaining enemies: {enemiesAlive} | Heroes standing: {heroesAlive}");
                    Console.WriteLine("==================================================");

                    TxtManager.Append(path, "--------------------------------------------------");
                    TxtManager.Append(path, $"  Remaining enemies: {enemiesAlive} | Heroes standing: {heroesAlive}");
                    TxtManager.Append(path, "==================================================");

                    round++;
                }
                if (round > _config.MaxCombatRounds)
                {
                    Console.WriteLine("Combat finished due to round limit!");
                }
                Console.WriteLine("Combat finished!");
                Console.WriteLine(TotalDamageMSG + combatHelper.Damage);
                Console.WriteLine(MostProfitableHeroMSG + combatHelper.MostProfitableHero(fighters));
                Console.WriteLine(EnemyDefeatedFirstMSG + combatHelper.EnemyDefeatedFirst(defeatedCharacters));

                TxtManager.Append(path, TotalDamageMSG + combatHelper.Damage);
                TxtManager.Append(path, MostProfitableHeroMSG + combatHelper.MostProfitableHero(fighters));
                TxtManager.Append(path, EnemyDefeatedFirstMSG + combatHelper.EnemyDefeatedFirst(defeatedCharacters));

                SafeStatsCSV(fighters);

            }
            else
            {
                Console.WriteLine(NoFightersMSG);
            }
        }

        private ACharacter EnemyTarget(List<ACharacter> fighters, ACharacter attacker)
        {
            List<ACharacter> targets = fighters
                .Where(f => f.IsAlive && f.CharType != attacker.CharType && f != attacker)
                .ToList();

            if (targets.Count == 0)
                return null;

            return targets[rand.Next(targets.Count)];
        }

        private ACharacter AllyTarget(List<ACharacter> fighters, ACharacter attacker)
        {
            List<ACharacter> targets = fighters
                .Where(f => f.IsAlive && f.CharType == attacker.CharType && f != attacker)
                .ToList();

            if (targets.Count == 0)
                return null;

            return targets[rand.Next(targets.Count)];
        }

        private void SafeStatsCSV(List<ACharacter> fighters)
        {
            CsvStatsWriter writer = new CsvStatsWriter();
            string heroesList = "";
            string result = fighters.Any(f => f.IsAlive && f.CharType == CharType.HERO) ? "Victory" : "Defeat";
            List<ACharacter> heroes = fighters.Where(f => f.CharType == CharType.HERO).ToList();

            for (int i = 0; i < heroes.Count; i++)
            {
                heroesList += heroes[i].Name + (i < heroes.Count - 1 ? ", " : "");
            }

            string enemiesList = "";
            var enemies = fighters.Where(f => f.CharType == CharType.ENEMY).ToList();
            for (int i = 0; i < enemies.Count; i++)
            {
                enemiesList += enemies[i].Name + (i < enemies.Count - 1 ? ", " : "");
            }

            var stats = new CombatResult
            {
                Date = DateTime.Now,
                Heroes = string.Join(", ", fighters.Where(f => f.CharType == CharType.HERO).Select(h => h.Name)),
                Enemies = string.Join(", ", fighters.Where(f => f.CharType == CharType.ENEMY).Select(e => e.Name)),
                Result = result,
                TotalRounds = round - 1,
                TotalDamage = combatHelper.Damage,
                BestHero = combatHelper.MostProfitableHero(fighters)
            };

            writer.AppendCombatStats(stats);
        }
    }
}