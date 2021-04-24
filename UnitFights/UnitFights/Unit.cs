using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitFights
{
    abstract class Unit
    {
        int healthPoints;
        public int HealthPoints 
        { 
            get => healthPoints ;
            set
            {
                if((healthPoints = value) <= 0)
                {
                    healthPoints = 0;
                    IsAlive = false;
                }
                else 
                {
                    IsAlive = true;
                    healthPoints = value;
                }
            }
        }
        public int DamagePoints { get; set; }
        public int MissChance { get; set; }
        public bool IsAlive { get; set; }

        public Unit(int HealthPoints, int DamagePoints, int MissChance)
        {
            this.HealthPoints = HealthPoints;
            this.DamagePoints = DamagePoints;
            this.MissChance = MissChance;
        }

        public void PrintUnitInfo()
        {
            Console.WriteLine($"Type:  {this.GetType().Name}\nHealth points:  {this.HealthPoints}\nDamage points:  {this.DamagePoints}");
        }
    }
}
