using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Core.Models
{
    public abstract class AEnemy : ACharacter
    {
        public EnemyType Type { get; set; }

        public AEnemy(string name) : base(name)
        {
            CurrentHealth = MaxHP;
            Speed = 10 * ((int)Type / 10);
            CharType = CharType.ENEMY;
        }

        /// <summary>
        /// Shows all parameters of an enemy
        /// </summary>
        /// <returns>a string of the full object parameters</returns>
        public override string ToString() => $"{Name} {MaxHP} {Type}";

        /// <summary>
        /// This method attacks a hero and reduces his current hp
        /// </summary>
        /// <param name="hero">the hero you want to attack</param>
        public void AttackTarget(ACharacter target)
        {
            target.CurrentHealth = (int)Type / 2;
            Console.WriteLine(target.CurrentHealth);
        }
    }
}
