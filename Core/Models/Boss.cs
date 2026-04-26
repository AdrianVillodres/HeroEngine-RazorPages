using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroEngine.Core.Models
{
    public class Boss : AEnemy
    {
        public Boss(string name) : base(name)
        {
            Type = EnemyType.Boss;
            Name = $"{Type} {name}";
            MaxHP = (int)Type;
        }
    }
}
