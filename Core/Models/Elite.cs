using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroEngine.Core.Enums;

namespace HeroEngine.Core.Models
{
    public class Elite : AEnemy
    {
        public Elite(string name) : base(name)
        {
            Type = EnemyType.Elite;
            Name = $"{Type} {name}";
            MaxHP = (int)Type;
        }
    }
}
