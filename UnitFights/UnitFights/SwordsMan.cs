using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitFights
{
    class SwordsMan : Unit
    {
        private const int ConstHealthPoints = 15;
        private const int ConstDamagePoints = 5;
        private const int ConstMissChance = 60;
        public SwordsMan()
            : base(ConstHealthPoints, ConstDamagePoints, ConstMissChance)
        {
        }
    }
}
