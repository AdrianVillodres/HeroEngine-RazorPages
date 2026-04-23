using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroEngine.Core.Enums;

namespace HeroEngine.Core.Models
{
    public class Minion : AEnemy
    {
        public Minion(string name) : base(name)
        {
            Type = EnemyType.Minion;
            Name = $"{Type} {name}";
            MaxHP = (int)Type;
        }
    }
}
