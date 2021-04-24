using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitFights
{
    class Mage : Unit
    {
        private const int ConstHealthPoints = 8;
        private const int ConstDamagePoints = 10;
        private const int ConstMissChance = 30;
        public Mage()
            : base(ConstHealthPoints, ConstDamagePoints, ConstMissChance)
        {
        }
    }
}
