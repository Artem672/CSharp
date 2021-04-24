using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    interface ISleep
    {
        public int SleepTime { get; set; }
        public void AnimalSleeping();
    }
}
