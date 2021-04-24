using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitFights
{
    class Archer : Unit
    {
        private const int ConstHealthPoints = 12;
        private const int ConstDamagePoints = 4;
        private const int ConstMissChance = 40;
        public Archer() 
            : base(ConstHealthPoints, ConstDamagePoints, ConstMissChance)
        {
        }
    }
}
