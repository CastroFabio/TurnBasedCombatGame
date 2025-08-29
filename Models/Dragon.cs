using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TurnBasedCombatGame.Models
{
    public class Dragon : Character
    {
        public Dragon(string name)
            : base(name)
        {
            HitPoints = 150;
            MaxHitPoints = 150;
            AttackPowerMin += 10;
            AttackPowerMax += 20;
            Defense += 5;
            Speed -= 2;
            if (Speed < 1)
                Speed = 1;
        }
    }
}
