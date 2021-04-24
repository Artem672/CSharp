using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    interface IWalk
    {
        public uint WalkSpeed { get; set; }
        public void AnimalWalking();
    }
}
