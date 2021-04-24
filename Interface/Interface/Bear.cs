using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class Bear : Animal
    {
        public Bear(string AnimalName, uint WalkSpeed, string FoodType, int SleepTime) : base(AnimalName, WalkSpeed, FoodType, SleepTime)
        {

        }    
    }
}
