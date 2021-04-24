using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    abstract class Animal : IEat,ISleep, IWalk
    {
        public string AnimalName { get; set; }

        uint walkSpeed;
        public uint WalkSpeed { get => walkSpeed; set => walkSpeed = value; }
        string foodType;
        public string FoodType { get => foodType; set => foodType = value; }
        int sleepTime;
        public int SleepTime { get => sleepTime; set => sleepTime = value; }

        public Animal(string AnimalName, uint WalkSpeed, string FoodType, int SleepTime)
        {
            this.AnimalName = AnimalName;
            this.WalkSpeed = WalkSpeed;
            this.FoodType = FoodType;
            this.SleepTime = SleepTime;
        }

        public void AnimalEating()
        {
            Console.WriteLine($"{this.GetType().Name}: {this.AnimalName} is eating: {this.FoodType}");
        }

        public void AnimalSleeping()
        {
            Console.WriteLine($"{this.GetType().Name}: {this.AnimalName} is sleeping for: {this.SleepTime}");
        }

        public void AnimalWalking()
        {
            Console.WriteLine($"{this.GetType().Name}: {this.AnimalName} is walking with speed: {this.WalkSpeed}");
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.AnimalName}\nWalk speed: {this.}"
        }
    }
}
